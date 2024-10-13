using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.Specifications
{
    public class ProductQuestionSpecification
    {
        public class GetByProductId : Specification<ProductQuestion>
        {
            public GetByProductId(int productId)
            {
                Query.Where(t => t.ProductId == productId)
                    .Include(x => x.AppUser);
            }
        }

        public class OpenQuestions : Specification<ProductQuestion>
        {
            public OpenQuestions()
            {
                Query.Where(t => t.OpenQuestion == true)
                    .Include(x => x.AppUser);
            }
        }

        public class OpenQuestionsByShopId : Specification<ProductQuestion>
        {
            public OpenQuestionsByShopId(int shopId)
            {
                Query.Where(t => t.OpenQuestion == true && t.Product.ShopId == shopId)
                    .Include(x => x.AppUser)
                    .Include(x => x.Product); 
            }
        }

    }
}
