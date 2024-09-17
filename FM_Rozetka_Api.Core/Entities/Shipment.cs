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
        // Додаткові поля
        public string Name { get; set; }  
        public string SurName { get; set; }  
        public string PhoneNumber { get; set; }       
        public string Email { get; set; }            

        // Інформація про доставку
        public string Region { get; set; }            
        public string City { get; set; }             
        public string PickupPoint { get; set; }       

    }
}
