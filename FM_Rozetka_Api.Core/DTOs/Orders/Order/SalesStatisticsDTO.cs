using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.Orders.Order
{
    public class SalesStatisticsDTO
    {
        public List<DailySalesStatisticDTO> DailyStatistics { get; set; }
        public List<SalesStatisticDTO> ProductStatistics { get; set; }
    }
}
