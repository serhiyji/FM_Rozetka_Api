using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.Specifications
{
    public static class CategoryProductSpecification
    {
        public class GetFirstLevelCategories : Specification<CategoryProduct>
        {
            public GetFirstLevelCategories()
            {
                Query.Where(c => c.Level == 1);
            }
        }

        public class GetSubCategoriesByTopId : Specification<CategoryProduct>
        {
            public GetSubCategoriesByTopId(int topId)
            {
                Query.Where(c => c.TopId == topId);
            }
        }
    }
}
