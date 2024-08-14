using Ardalis.Specification;
using Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.Specifications
{
    public static class BrandSpecification
    {
        public class GetByPagination : Specification<Brand>
        {
            public GetByPagination(int page, int pageSize)
            {
                Query.Skip((page - 1) * pageSize).Take(pageSize);
            }
        }
    }
}
