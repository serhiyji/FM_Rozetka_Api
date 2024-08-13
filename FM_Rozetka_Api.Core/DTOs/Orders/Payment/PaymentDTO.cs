
namespace FM_Rozetka_Api.Core.DTOs.Orders.Payment
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
    }
}
