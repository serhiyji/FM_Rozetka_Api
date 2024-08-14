
namespace FM_Rozetka_Api.Core.DTOs.Seller
{
    public class CreateSellerApplicationDTO
    {
        public string CompanyName { get; set; }
        public string Website { get; set; }
        public bool HasNoWebsite { get; set; }

        public string FullName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsNonResident { get; set; }
    }

}
