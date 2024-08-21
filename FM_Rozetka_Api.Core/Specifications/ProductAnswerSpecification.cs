using Ardalis.Specification;
using FM_Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.Specifications
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
