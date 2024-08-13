using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Telegram.Bot.Types;
using FM_Rozetka_Api.Core.Entities.Telegram;

namespace FM_Rozetka_Api.Core.Specifications
{
    public static class TelegramUserSpecification
    {
        public class GetByTelegramUserId : Specification<TelegramUser>
        {
            public GetByTelegramUserId(string _TelegramUserId)
            {
                Query.Where(i => i.TelegramUserId == _TelegramUserId);
            }
        }

        public class GetByPhoneNumber : Specification<TelegramUser>
        {
            public GetByPhoneNumber(string phoneNumber)
            {
                Query.Where(i => i.TelegramPhoneNumber == phoneNumber);
            }
        }
    }
}
