using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Entities.Telegram;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Specifications;
using Microsoft.Extensions.Configuration;

using System.Text;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace FM_Rozetka_Api.Core.Services
{
    public class TelegramApiHandlerService : ITelegramApiHandlerService
    {
        private static ITelegramBotClient botClient;
        private readonly IRepository<TelegramUser> _telegramUserRepo;
        private readonly IRepository<PhoneConfirmation> _phoneConfirmationRepo;
        private readonly ITelegramUserService _telegramUserService;
        private readonly IConfiguration _configuration;

        #region Input Actions
        public delegate Task InputActionDelegate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);
        private readonly Dictionary<string, InputActionDelegate> InputActionsForStatusStateNull;
        #endregion

        private static readonly string AskPhoneNumber = "Ваш номер телефону залишатиметься конфіденційним та не буде переданий третім особам\\. Ми використаємо його лише для того\\, щоб зв'язатися з вами\\. Дякуємо за довіру та розуміння\\.";

        private static readonly List<string> CancelWordsForWaitConfirmPhoneNumber = new()
        {
            "Скасувати", "/menu", "Головне меню"
        };

        #region markups

        private static readonly KeyboardButton PhoneNumberShare = new("Надати номер телефону") { RequestContact = true };

        private static readonly ReplyKeyboardMarkup MarkupCancelButtton = new ReplyKeyboardMarkup(new List<List<KeyboardButton>>()
        {
            new() { new("Скасувати") }
        })
        { ResizeKeyboard = true };

        private static readonly ReplyKeyboardMarkup MarkupTrySharePhoneNumber = new(new List<List<KeyboardButton>>()
        {
            new() { PhoneNumberShare },
            new() { new("Скасувати") }
        })
        { ResizeKeyboard = true };

        private static readonly ReplyKeyboardMarkup MarkupMainMenu = new ReplyKeyboardMarkup(new List<List<KeyboardButton>>()
        {
            new() { new("Головне меню") },
            new() { new("Поділитися номером телефону") },
        })
        { ResizeKeyboard = true };

        #endregion

        #region Ctor
        public TelegramApiHandlerService
            (
                IRepository<TelegramUser> tgUserRepo,
                IRepository<PhoneConfirmation> phoneConfirmationRepo,
                IConfiguration configuration,
                ITelegramUserService telegramUserService
            )
        {
            _configuration = configuration;
            _telegramUserRepo = tgUserRepo;
            _telegramUserService = telegramUserService;
            _phoneConfirmationRepo = phoneConfirmationRepo;
            botClient = new TelegramBotClient(_configuration["TelegramAPI:AccessToken"]);
            CancellationTokenSource access_token = new CancellationTokenSource();
            ReceiverOptions receiverOptions = new ReceiverOptions { AllowedUpdates = { } };
            botClient.ReceiveAsync(OnCreateMessage, OnErrorMessage, receiverOptions, access_token.Token);

            InputActionsForStatusStateNull = new(new List<KeyValuePair<string, InputActionDelegate>>()
            {
                new ("Головне меню", SendMainMenu),
                new ("Відмінити", SendMainMenu),
                new ("Поділитися номером телефону", StartWaitPhoneNumber)
            });
        }
        #endregion

        public async Task OnCreateMessage(ITelegramBotClient _botClient, Update update, CancellationToken cancellationToken)
        {
            // Only process text and contact messages
            if (!(update.Message?.Type == MessageType.Text || update.Message?.Type == MessageType.Contact))
                return;

            await CreateOrUpdateTgUser(_botClient, update, cancellationToken);

            TelegramUser user = await _telegramUserRepo.GetItemBySpec(new TelegramUserSpecification.GetByTelegramUserId(update.Message.From.Id.ToString()));
            if (user == null) { return; }
            
            if (user.StatusState == StatusStateTelegramUser.Null)
            {
                InputActionDelegate? action = (InputActionsForStatusStateNull.TryGetValue(update.Message.Text, out action)) ? action : SendMainMenu;
                action?.Invoke(botClient, update, cancellationToken);
            }
            else if (user.StatusState == StatusStateTelegramUser.WaitConfirmPhoneNumber)
            {
                if (update.Message.Type == MessageType.Text && CancelWordsForWaitConfirmPhoneNumber.Contains(update.Message.Text))
                {
                    await _telegramUserService.ChangeUserStatusState(user.TelegramUserId, StatusStateTelegramUser.Null);
                    await SendMainMenu(botClient, update, cancellationToken);
                }
                if (update.Message.Type == MessageType.Contact)
                {
                    await _telegramUserService.ChangeUserStatusState(user.TelegramUserId, StatusStateTelegramUser.Null);
                    await SendMainMenu(botClient, update, cancellationToken);
                    if (!string.IsNullOrEmpty(user.TelegramPhoneNumber))
                    {
                        PhoneConfirmation phoneConfirmation = await _phoneConfirmationRepo.GetItemBySpec(new PhoneConfirmationSpecification.GetByPhoneNumber(user.TelegramPhoneNumber));
                        if(phoneConfirmation != null && DateTime.UtcNow > phoneConfirmation.CreateTime.AddMinutes(50))
                        {
                            if (await SendConfirmationCodeForPhone(phoneConfirmation.Phone, phoneConfirmation.Code))
                            {
                                phoneConfirmation.IsSendInTelegram = true;
                                await _phoneConfirmationRepo.Update(phoneConfirmation);
                                await _phoneConfirmationRepo.Save();
                            }
                        }
                    }
                }
            }
        }

        public async Task OnErrorMessage(ITelegramBotClient _botClient, Exception e, CancellationToken cancellationToken)
        {
            if (e is ApiRequestException requestException)
            {
                await botClient.SendTextMessageAsync("", e.Message.ToString());
            }
        }

        #region Validation

        private async Task CreateOrUpdateTgUser(ITelegramBotClient _botClient, Update update, CancellationToken cancellationToken)
        {
            TelegramUser user = await _telegramUserRepo.GetItemBySpec(new TelegramUserSpecification.GetByTelegramUserId(update.Message.From.Id.ToString()));
            string userPhone = TelegramUserService.RemovePlusSign(update?.Message?.Contact?.PhoneNumber);
            if (user == null)
            {
                TelegramUser newuser = new TelegramUser()
                {
                    CreatedDate = DateTime.UtcNow,
                    TelegramChatId = update.Message.Chat.Id.ToString(),
                    TelegramUserId = update?.Message?.From?.Id.ToString(),
                    TelegramPhoneNumber = null,
                    TgUserName = update?.Message?.Chat?.Username
                };
                await _telegramUserRepo.Insert(newuser);
                await _telegramUserRepo.Save();
            }
            else
            {
                await _telegramUserService.CheckAndUpdatePhoneTgUser(user.Id, userPhone);
            }
        }

        #endregion

        #region Send messages
        private async Task<bool> SendMessageToUserByUserId(long userId, string message, ParseMode parseMode, ReplyKeyboardMarkup inline = null, int replyMessageId = 0)
        {
            try
            {
                foreach (var item in CreateResponseActionMarkdownV2(message))
                {
                    Message msg = await botClient.SendTextMessageAsync(userId, item, null, parseMode, null, null, null, null, replyMessageId != 0 ? replyMessageId : null, null, inline);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        private async Task<bool> SendMessageToUserByUserId(string userId, string message, ParseMode parseMode, ReplyKeyboardMarkup inline = null, int replyMessageId = 0)
        => await SendMessageToUserByUserId(long.Parse(userId), message, parseMode, inline, replyMessageId);

        private async Task SendMainMenu(ITelegramBotClient _botClient, Update update, CancellationToken cancellationToken)
        {
            string text = $"📒 *Головне меню*\n\nДля перегляду більшого набору інформації виберіть відповідну команду зі списку";
            await SendMessageToUserByUserId(update.Message.From.Id, text, ParseMode.Markdown, MarkupMainMenu);
        }

        private IEnumerable<string> CreateResponseActionMarkdownV2(string message)
        {
            int chunkSize = 2096;

            // If message len > 2096 symbols
            if (string.IsNullOrEmpty(message)) { return Enumerable.Empty<string>(); }

            List<string> results = new List<string>();
            StringBuilder msg = new StringBuilder();
            int messageLength = 0;
            byte[] bytes = Encoding.UTF32.GetBytes(message);
            for (int i = 0; i < bytes.Length; i += 4)
            {
                uint codepoint = BitConverter.ToUInt32(bytes, i);
                int charSize = (codepoint < 128) ? 1 : (codepoint < 32768) ? 2 : 4;
                if (messageLength + charSize > chunkSize)
                {
                    results.Add(msg.ToString());
                    msg.Clear();
                    messageLength = 0;
                }
                msg.Append((charSize < 4) ? Convert.ToChar(codepoint) : char.ConvertFromUtf32((int)codepoint));
                messageLength += charSize;
            }
            if (msg.Length > 0)
            {
                results.Add(msg.ToString());
            }
            return results;
        }

        #endregion

        private async Task StartWaitPhoneNumber(ITelegramBotClient _botClient, Update update, CancellationToken cancellationToken)
        {
            TelegramUser user = await _telegramUserRepo.GetItemBySpec(new TelegramUserSpecification.GetByTelegramUserId(update.Message.From.Id.ToString()));
            if (user == null) { return; }
            await _telegramUserService.ChangeUserStatusState(user.TelegramUserId, StatusStateTelegramUser.WaitConfirmPhoneNumber);
            await SendMessageToUserByUserId(update.Message.From.Id, AskPhoneNumber, ParseMode.MarkdownV2, MarkupTrySharePhoneNumber);
        }

        public async Task<bool> SendConfirmationCodeForPhone(string phoneNumber, string code)
        {
            TelegramUser telegramUser = await _telegramUserRepo.GetItemBySpec(new TelegramUserSpecification.GetByPhoneNumber(TelegramUserService.RemovePlusSign(phoneNumber)));
            if (telegramUser != null)
            {
                return await SendMessageToUserByUserId(telegramUser.TelegramUserId, $"Ваш код підтвердженя для телефону : {code}", ParseMode.Markdown);
            }
            return false;
        }
    }
}
