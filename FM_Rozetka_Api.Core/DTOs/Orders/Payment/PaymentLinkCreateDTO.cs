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

        public CustomerInfoDTO AllData { get; set; }
    }

    public class CustomerInfoDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Region { get; set; }
        public int City { get; set; }
        public int PickupPoint { get; set; }
    }


}
