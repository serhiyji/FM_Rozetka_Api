
namespace FM_Rozetka_Api.Core.DTOs.User
{
    public class UserModeratorShopDTO
    {
        public string AppUserId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int IdModeratorShop { get; set; }
    }
}
