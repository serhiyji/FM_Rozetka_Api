using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.Specifications
{
    public static class ReviewSpecification
    {
        public class GetByProductId : Specification<Review>
        {
            public GetByProductId(int productId)
            {
                Query.Where(item => item.ProductId == productId).
                   Include(item => item.AppUser);
            }
        }
    }
}
