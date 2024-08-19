using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FM_Rozetka_Api.Core.Specifications.ProductAnswerSpecification
{
    public class ProductAnswerSpecification
    {
        public class GetByQustionId : Specification<ProductAnswer>
        {
            public GetByQustionId(int questionId)
            {
                Query.Where(t => t.QuestionID == questionId)
                    .Include(x => x.AppUser);
            }
        }

        public class GetCountAnswer : Specification<ProductAnswer>
        {
            public GetCountAnswer(int questionId)
            {
                Query.Where(t => t.QuestionID == questionId);
            }
        }
    }

}
