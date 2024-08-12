using FM_Rozetka_Api.Core.DTOs.Products.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.CategoryProduct
{
    public class CategoryProductDTO
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int? TopId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CategoryProductDTO> SubCategories { get; set; } 
    }
}
