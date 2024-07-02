using FM_Rozetka_Api.Core.Entities.Telegram;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Specifications;

namespace FM_Rozetka_Api.Core.Services
{
    public class TelegramUserService : ITelegramUserService
    {
        private readonly IRepository<TelegramUser> _telegramUserRepo;
        public TelegramUserService(IRepository<TelegramUser> telegramUserRepo)
        {
            _telegramUserRepo = telegramUserRepo;   
        }
        public async Task CheckAndUpdatePhoneTgUser(int Id, string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber)) { return; }
            TelegramUser user = await _telegramUserRepo.GetByID(Id);
            if (user == null) { return; }
            if (user.TelegramPhoneNumber == phoneNumber) { return; }
            user.TelegramPhoneNumber = phoneNumber;
            await _telegramUserRepo.Update(user);
            await _telegramUserRepo.Save();
        }

        public async Task ChangeUserStatusState(string telegramUserId, StatusStateTelegramUser newStatusState)
        {
            TelegramUser user = await _telegramUserRepo.GetItemBySpec(new TelegramUserSpecification.GetByTelegramUserId(telegramUserId));
            if (user == null) { return; }
            user.StatusState = newStatusState;
            await _telegramUserRepo.Update(user);
            await _telegramUserRepo.Save();
        }

        public async Task<bool> IsNumberInTelegramUsers(string phoneNumber)
        {
            TelegramUser telegramUser = await _telegramUserRepo.GetItemBySpec(new TelegramUserSpecification.GetByPhoneNumber(RemovePlusSign(phoneNumber)));
            return telegramUser != null;
        }

        public static string RemovePlusSign(string input)
        {
            return string.IsNullOrEmpty(input) ? input : input[0] == '+' ? input.Substring(1) : input;
        }
    }
}
