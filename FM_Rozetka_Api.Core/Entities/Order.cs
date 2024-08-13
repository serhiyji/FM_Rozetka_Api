using FM_Rozetka_Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Entities
{
    public class Order: IEntity
    //Призначення: Зберігає інформацію про замовлення, зроблені користувачами.
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }

        public List<OrderItem> OrderItems { get; set; }
        public List<Payment> Payments { get; set; }
        public List<OrderStatusHistory> OrderStatusHistories { get; set; }
        public List<Shipment> Shipments { get; set; }
    }
}
