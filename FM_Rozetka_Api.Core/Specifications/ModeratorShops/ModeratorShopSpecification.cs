using Ardalis.Specification;
using FM_Rozetka_Api.Core.DTOs.Shops.ModeratorShop;
using FM_Rozetka_Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FM_Rozetka_Api.Core.Specifications.ModeratorShops
{
    public static class ModeratorShopSpecification
    {
        public class GetUserModeratorShop : Specification<ModeratorShop>
        {
            public GetUserModeratorShop(int shopid)
            {
                Query.Where(x => x.ShopId == shopid)
                  .Include(x => x.AppUser);
            }
        }
    }


}
