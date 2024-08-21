using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FM_Rozetka_Api.Core.Specifications.ReviewSpecification
{
    public class ReviewSpecification
    {
        public class GetByProductId : Specification<Review>
        {
            public GetByProductId(int productId)
            {
                Query.Where(t => t.ProductId == productId)
                    .Include(x => x.AppUser);
            }
        }
    }
}
