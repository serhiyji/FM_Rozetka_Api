using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;

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
