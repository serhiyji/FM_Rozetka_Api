
namespace FM_Rozetka_Api.Core.DTOs.CartItem
{
    public class CartItemCreateDTO
    {
        public string AppUserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
