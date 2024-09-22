using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.Specifications
{
    public static class ViewedProductSpecification
    {
        public class GetByAppUserIdCount : Specification<ViewedProduct>
        {
            public GetByAppUserIdCount(string appUserId, int count)
            {
                Query.Where(item => item.AppUserId ==  appUserId).OrderByDescending(item => item.CreatedAt).Take(count).Include(item => item.Product);
            }
        }
        public class GetByAppUserIdAndProductId : Specification<ViewedProduct>
        {
            public GetByAppUserIdAndProductId(string appUserId, int productId)
            {
                Query.Where(item => item.AppUserId == appUserId && item.ProductId == productId);
            }
        }
        public class GetRecommendedProductsByAppUserIdCount : Specification<ViewedProduct>
        {
            public GetRecommendedProductsByAppUserIdCount(string appUserId, int count)
            {
                Query.Where(item => item.AppUserId == appUserId).OrderBy(item => item.Count).Take(count).Include(item => item.Product);
            }
        }
    }
}
