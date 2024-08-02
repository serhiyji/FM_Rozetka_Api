using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FM_Rozetka_Api.Core.Entities
{
    public class AppUser : IdentityUser
    {
        [Required, MaxLength(64)]
        public string FirstName { get; set; } = string.Empty;
        [Required, MaxLength(64)]
        public string SurName { get; set; } = string.Empty;
        [Required, MaxLength(64)]
        public string LastName { get; set; } = string.Empty;
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public List<Adress> Adresses { get; set; }
        public List<CartItem> CartItems { get; set; }
        public List<Favorite> Favorites { get; set; }
        public List<ModeratorShop> ModeratorShops { get; set; }
        public List<Order> Orders { get; set; }
        public List<ProductAnswer> ProductAnswers { get; set; }
        public List<ProductQuestion> ProductQuestions { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Shop> Shops { get; set; }
    }
}
