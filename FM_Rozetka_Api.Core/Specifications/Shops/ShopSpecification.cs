using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using FM_Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.Specifications.Shops
{
    public class ShopSpecification : Specification<Shop>
    {
        public class GetShopByUserId : Specification<Shop>
        {
            public GetShopByUserId(string id)
            {
                Query.Where(c => c.AppUserId == id);
            }
        }

    }
    
}
