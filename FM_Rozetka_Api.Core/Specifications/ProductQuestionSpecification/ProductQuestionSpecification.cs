using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FM_Rozetka_Api.Core.Specifications.ProductQuestionSpecification
{
    public class ProductQuestionSpecification
    {
        public class GetByProductId : Specification<ProductQuestion>
        {
            public GetByProductId(int productId)
            {
                Query.Where(t => t.ProductId == productId)
                    .Include(x => x.AppUser);
            }
        }
    }
}
