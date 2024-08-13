
namespace FM_Rozetka_Api.Core.DTOs.Orders.OrderStatusHistory
{
    public class OrderStatusHistoryDTO
    {
        public int OrderId { get; set; }
        public string Status { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}
