using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;
using Rozetka_Api.Core.Entities;

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

        public class GetByPagination : Specification<Product>
        {
            public GetByPagination(int page, int pageSize)
            {
                Query.Skip((page - 1) * pageSize).Take(pageSize);
            }
        }

        public class GetByBrandId : Specification<Product>
        {
            public GetByBrandId(int brandId)
            {
                Query.Where(item => item.BrandId == brandId);
            }
        }

        public class GetByCreationDate : Specification<Product>
        {
            public GetByCreationDate(int count)
            {
                Query.OrderBy(item => item.CreatedAt).Take(count);
            }
        }

        public class GetByShowings : Specification<Product>
        {
            public GetByShowings(int count)
            {
                Query.OrderBy(item => item.Showings).Take(count);
            }
        }

        public class GetByFavoritesIds : Specification<Product>
        {
            public GetByFavoritesIds(List<int> favoritesIds, int pageNumber, int pageSize)
            {
                Query.Where(p => favoritesIds.Contains(p.Id))
                     .Skip((pageNumber - 1) * pageSize)
                     .Take(pageSize); 

            }
        }

        public class GetByNameSearch : Specification<Product>
        {
            public GetByNameSearch(string searchTerm, int pageNumber, int pageSize)
            {
                Query.Where(p => p.Name.ToLower().Contains(searchTerm.ToLower())).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            }
        }
    }
}
