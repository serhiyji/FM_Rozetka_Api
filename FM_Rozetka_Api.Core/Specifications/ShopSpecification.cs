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
                Query.Where(c => c.AppUserId == id);
            }
        }
    }
}
