using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.Specifications
{
    public static class CategoryProductSpecification
    {
        public class GetCountSubcategories : Specification<CategoryProduct>
        {
            public GetCountSubcategories(int id)
            {
                Query.Where(x => x.TopId == id);
            }
        }
    }
}
