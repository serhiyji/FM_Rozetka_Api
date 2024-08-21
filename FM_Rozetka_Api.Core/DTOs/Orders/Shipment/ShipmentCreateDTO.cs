
namespace FM_Rozetka_Api.Core.DTOs.Orders.Shipment
{
    public class ShipmentCreateDTO
    {
        public int OrderId { get; set; }
        public DateTime ShipmentDate { get; set; }
        public string TrackingNumber { get; set; }
        public string Carrier { get; set; }
        public string Status { get; set; }
    }
}
