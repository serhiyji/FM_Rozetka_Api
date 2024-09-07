
namespace FM_Rozetka_Api.Core.DTOs.Orders.Order
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderId { get; set; }
    }
}
