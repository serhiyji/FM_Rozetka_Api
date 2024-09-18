using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs
{
    public class PaymentCashDTO
    {
        public List<int> CartItemIds { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Area { get; set; }
        public string Settlement { get; set; }
        public string DeliveryBranch { get; set; }
        public string PaymentMethod { get; set; }
    }
}
