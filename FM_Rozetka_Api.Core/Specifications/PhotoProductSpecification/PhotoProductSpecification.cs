using Ardalis.Specification;
using FM_Rozetka_Api.Core.DTOs.Products.PhotoProduct;
using FM_Rozetka_Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FM_Rozetka_Api.Core.Specifications.PhotoProductSpecification
{
    public class PhotoProductSpecification
    {
        public class GetByProductId : Specification<PhotoProduct>
        {
            public GetByProductId(int productId)
            {
                Query.Where(t => t.ProductId == productId);
            }
        }
    }
}
