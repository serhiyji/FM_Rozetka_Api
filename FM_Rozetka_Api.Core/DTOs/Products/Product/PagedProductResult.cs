using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.Products.Product
{
    public class PagedProductResult
    {
        public IEnumerable<ProductDTO> Products { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int? NextPage { get; set; }
        public int? PreviousPage { get; set; }
    }

}
