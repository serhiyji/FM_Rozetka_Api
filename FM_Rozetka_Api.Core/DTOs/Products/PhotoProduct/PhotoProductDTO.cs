using FM_Rozetka_Api.Core.DTOs.Products.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.Products.PhotoProduct
{
    public class PhotoProductDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string NameImage { get; set; }
    }
}
