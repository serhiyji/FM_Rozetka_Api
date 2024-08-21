using FM_Rozetka_Api.Core.Entities.Telegram;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface ITelegramUserService
    {
        Task CheckAndUpdatePhoneTgUser(int Id, string phoneNumber);
        Task ChangeUserStatusState(string telegramUserId, StatusStateTelegramUser newStatusState);
        Task<bool> IsNumberInTelegramUsers(string phoneNumber);
    }
}
