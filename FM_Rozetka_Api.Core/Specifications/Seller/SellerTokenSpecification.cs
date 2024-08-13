using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.Specifications.Seller
{
    public static class SellerTokenSpecification
    {
        public class GetAllActivityApplications : Specification<SellerApplication>
        {
            public GetAllActivityApplications()
            {
                Query.Where(t => t.ProcessedApplication == false);
            }
        }
    }
}
