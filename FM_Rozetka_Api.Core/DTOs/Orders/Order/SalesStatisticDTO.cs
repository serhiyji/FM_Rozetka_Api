using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.Orders.Order
{

    public class SalesStatisticDTO
    {
        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [JsonProperty("productName")]
        public string ProductName { get; set; }

        [JsonProperty("quantitySold")]
        public int QuantitySold { get; set; }

        [JsonProperty("totalRevenue")]
        public decimal TotalRevenue { get; set; }
    }


}
