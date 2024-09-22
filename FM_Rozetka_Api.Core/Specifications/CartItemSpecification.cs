using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.Specifications
{
    public static class CartItemSpecification
    {
        public class GetByAppUserId : Specification<CartItem>
        {
            public GetByAppUserId(string appUserId)
            {
                Query.Where(item => item.AppUserId == appUserId);
            }
        }

        public class GetByIds : Specification<CartItem>
        {
            public GetByIds(int[] ids)
            {
                Query.Where(item => ids.Contains(item.Id));
            }
        }
    }
}
