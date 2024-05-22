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
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }

        public AppUser User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<OrderStatusHistory> OrderStatusHistories { get; set; }
        public ICollection<Shipment> Shipments { get; set; }
    }
}
