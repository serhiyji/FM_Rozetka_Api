using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.Specifications
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

        public class GetModeratorShopByAppUserId : Specification<ModeratorShop>
        {
            public GetModeratorShopByAppUserId(string AppUserId)
            {
                Query.Where(x => x.AppUserId == AppUserId);
            }
        }

    }
}