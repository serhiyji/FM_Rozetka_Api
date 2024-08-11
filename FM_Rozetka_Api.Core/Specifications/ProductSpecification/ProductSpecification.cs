using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FM_Rozetka_Api.Core.Specifications.ProductSpecification
{
    public class ProductSpecification
    {
        public class GetByCategoryID : Specification<Product>
        {
            public GetByCategoryID(int productId)
            {
                Query.Where(t => t.CategoryProductId == productId);
            }
        }

        public class GetByShopID: Specification<Product>
        {
             
            public GetByShopID(int shopId)
            {
                Query.Where(t => t.ShopId == shopId);
            }
        }
    
       
    }
}
