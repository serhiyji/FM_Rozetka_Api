using FM_Rozetka_Api.Core.Interfaces;

namespace FM_Rozetka_Api.Core.Entities.Telegram
{
    public enum StatusStateTelegramUser
    {
        Null = 0,
        WaitConfirmPhoneNumber = 1
    }
    public class TelegramUser : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string TelegramChatId { get; set; }
        public string TelegramUserId { get; set; }
        public string? TelegramPhoneNumber { get; set; } = null;
        public string TgUserName { get; set; }
        public StatusStateTelegramUser StatusState { get; set; }
    }
}
