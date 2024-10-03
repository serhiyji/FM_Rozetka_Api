
namespace FM_Rozetka_Api.Core.DTOs.Orders.Shipment
{
    public class ShipmentDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public DateTime ShipmentDate { get; set; }
        public string TrackingNumber { get; set; }
        public string Carrier { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string PickupPoint { get; set; }
    }
}
