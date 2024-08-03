using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.Products.Product
{
    public class ProductCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Stars { get; set; }
        public int Stock { get; set; }
        public IFormFile? ImageFile { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int ShopId { get; set; }
        public int CategoryProductId { get; set; }
        public int CountryProductionId { get; set; }
    }
}
