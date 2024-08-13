
namespace FM_Rozetka_Api.Core.DTOs.Address
{
    public class AddressUpdateDTO
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
    }
}
