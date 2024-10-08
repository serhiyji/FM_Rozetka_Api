using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.Specifications
{
    public class ShopSpecification : Specification<Shop>
    {
        public class GetShopByUserId : Specification<Shop>
        {
            public GetShopByUserId(string id)
            {
                Query.Include(company => company.Company)
                    .Where(c => c.AppUserId == id);
            }
        }

        public class GetShopByModeratorId : Specification<Shop>
        {
            public GetShopByModeratorId(string moderatorId)
            {
                Query.Include(shop => shop.ModeratorShop)  
                     .Where(shop => shop.ModeratorShop.Any(ms => ms.AppUserId == moderatorId));
            }
        }
    }
}
