
using FM_Rozetka_Api.Core.DTOs.Products.Product;

namespace FM_Rozetka_Api.Core.DTOs.Favorite
{
    public class FavoriteDTO
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }
    }
}
