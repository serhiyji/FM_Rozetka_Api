using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.Specifications
{
    public class PhotoProductSpecification
    {
        public class GetByProductId : Specification<PhotoProduct>
        {
            public GetByProductId(int productId)
            {
                Query.Where(t => t.ProductId == productId);
            }
        }
    }
}
