using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.Orders.OrderStatusHistory
{
    public class OrderStatusHistoryUpdateDTO
    {
        public int OrderId { get; set; }
        public string Status { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}
