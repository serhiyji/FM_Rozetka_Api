using FM_Rozetka_Api.Core.Entities.Telegram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface ITelegramUserService
    {
        Task CheckAndUpdatePhoneTgUser(int Id, string phoneNumber);
        Task ChangeUserStatusState(string telegramUserId, StatusStateTelegramUser newStatusState);
        Task<bool> IsNumberInTelegramUsers(string phoneNumber);
    }
}
