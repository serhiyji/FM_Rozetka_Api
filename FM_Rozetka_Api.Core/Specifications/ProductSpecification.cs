using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.Specifications
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

        public class GetByShopID : Specification<Product>
        {

            public GetByShopID(int shopId)
            {
                Query.Where(t => t.ShopId == shopId);
            }
        }

        public class GetPagedProducts : Specification<Product>
        {
            public GetPagedProducts(int pageNumber, int pageSize)
            {
                Query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            }
        }

        public class GetByBrandId : Specification<Product>
        {
            public GetByBrandId(int brandId)
            {
                Query.Where(item => item.BrandId == brandId);
            }
        }
    }
}
