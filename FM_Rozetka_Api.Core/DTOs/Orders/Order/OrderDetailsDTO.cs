using FM_Rozetka_Api.Core.DTOs.Products.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.Orders.Order
{
    public class OrderDetailsDTO
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public List<ProductDetailsDTO> Products { get; set; }
        public decimal TotalAmount { get; set; }
    }

}
