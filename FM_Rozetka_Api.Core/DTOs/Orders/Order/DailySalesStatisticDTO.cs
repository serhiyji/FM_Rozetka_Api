using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.Orders.Order
{
    public class DailySalesStatisticDTO
    {
        public DateTime Date { get; set; }
        public int TotalQuantitySold { get; set; }
        public decimal TotalRevenue { get; set; }
    }

}
