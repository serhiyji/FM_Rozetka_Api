using FM_Rozetka_Api.Core.Interfaces;

namespace FM_Rozetka_Api.Core.Entities
{
    public class Shipment: IEntity
    //Призначення: Зберігає інформацію про доставку замовлень.
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime ShipmentDate { get; set; }
        public string TrackingNumber { get; set; }
        public string Carrier { get; set; }
        public string Status { get; set; }

    }
}
