using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
