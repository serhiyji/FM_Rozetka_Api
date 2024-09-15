using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.Orders.Payment
{
    public class PaymentLinkCreateDTO
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public int[] CartItemIds { get; set; }
    }

}
