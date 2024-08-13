using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.ProductBrand
{
    public class ProductBrandUpdateDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int BrandId { get; set; }
    }
}
