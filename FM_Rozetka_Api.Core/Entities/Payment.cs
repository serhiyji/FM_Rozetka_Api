using FM_Rozetka_Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Entities
{
    public class Payment: IEntity
    //Призначення: Зберігає інформацію про платежі за замовлення
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }

        public Order Order { get; set; }
    }
}
