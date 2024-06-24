using FM_Rozetka_Api.Core.Entities.Telegram;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Specifications;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private readonly IRepository<TelegramUser> _tgUserRepo;
        private readonly IConfiguration _configuration;

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

        #endregion

        #region Ctor
        public TelegramApiHandlerService
            (
                IRepository<TelegramUser> tgUserRepo,
                IConfiguration configuration
            )
        {
            _configuration = configuration;
            _tgUserRepo = tgUserRepo;
            botClient = new TelegramBotClient(_configuration["TelegramAPI:AccessToken"]);
            CancellationTokenSource access_token = new CancellationTokenSource();
            ReceiverOptions receiverOptions = new ReceiverOptions { AllowedUpdates = { } };
            botClient.ReceiveAsync(OnCreateMessage, OnErrorMessage, receiverOptions, access_token.Token);
        }
        #endregion

        public async Task OnCreateMessage(ITelegramBotClient _botClient, Update update, CancellationToken cancellationToken)
        {
            // Only process text and contact messages
            if (!(update.Message?.Type == MessageType.Text || update.Message?.Type == MessageType.Contact))
                return;

            await CreateOrUpdateTgUser(_botClient, update, cancellationToken);

            if (update.Message.Type == MessageType.Text)
            {
                await SendMessageToUserByUserId(update.Message.From.Id, update.Message.Text, ParseMode.Markdown);
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
            TelegramUser user = await _tgUserRepo.GetItemBySpec(new TelegramUserSpecification.GetByTelegramUserId(update.Message.From.Id.ToString()));
            string userPhone = update?.Message?.Contact?.PhoneNumber;
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
                await _tgUserRepo.Insert(newuser);
                await _tgUserRepo.Save();
            }
            else
            {
                //await _tgUserService.CheckAndUpdatePhoneTgUser(user.Id, userPhone);
            }
        }

        #endregion

        #region Send messages
        private async Task SendMessageToUserByUserId(long userId, string message, ParseMode parseMode, ReplyKeyboardMarkup inline = null, int replyMessageId = 0)
        {

            foreach (var item in CreateResponseActionMarkdownV2(message))
            {
                Message msg = await botClient.SendTextMessageAsync(userId, item, null, parseMode, null, null, null, null, replyMessageId != 0 ? replyMessageId : null, null, inline);
            }
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
    }
}
