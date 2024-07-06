using FM_Rozetka_Api.Core.Interfaces;

namespace FM_Rozetka_Api.Core.Entities
{
    public class PhoneConfirmation : IEntity
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string Code { get; set; }
        public string Phone { get; set; }
        public bool IsSendInTelegram { get; set; } = false;
    }
}
