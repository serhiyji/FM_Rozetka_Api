using FM_Rozetka_Api.Core.Interfaces;

namespace FM_Rozetka_Api.Core.Entities
{
    public class SellerApplication : IEntity
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Website { get; set; }
        public bool HasNoWebsite { get; set; }

        public string FullName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsNonResident { get; set; }

        public bool ProcessedApplication { get; set; } = false;
        public bool IsApproved { get; set; }
    }
}
