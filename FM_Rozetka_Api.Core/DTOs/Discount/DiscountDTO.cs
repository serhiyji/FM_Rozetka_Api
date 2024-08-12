
namespace FM_Rozetka_Api.Core.DTOs.Discount
{
    public class DiscountDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
