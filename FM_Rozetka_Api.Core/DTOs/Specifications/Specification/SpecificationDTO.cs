using FM_Rozetka_Api.Core.DTOs.Products.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.Specifications.Specification
{
    public class SpecificationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int CategorySpecificationId { get; set; }
        public int ProductId { get; set; }
    }
}
