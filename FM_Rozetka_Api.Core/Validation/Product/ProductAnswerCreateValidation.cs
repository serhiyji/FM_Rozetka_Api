using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.Products.ProductAnswer;
using FM_Rozetka_Api.Core.DTOs.Products.ProductQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Validation.Product
{
    public class ProductAnswerCreateValidation : AbstractValidator<ProductAnswerCreateDTO>
    {
        public ProductAnswerCreateValidation()
        {
            RuleFor(x => x.QuestionID)
            .GreaterThan(0).WithMessage("QuestionID must be greater than 0.");

            RuleFor(x => x.AppUserId)
                .NotEmpty().WithMessage("AppUserId cannot be empty.");

            RuleFor(x => x.AnswerText)
                .NotEmpty().WithMessage("AnswerText cannot be empty.")
                .MaximumLength(500).WithMessage("AnswerText cannot exceed 500 characters.");

            RuleFor(x => x.CreatedAt)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("CreatedAt cannot be in the future.");

        }
    }
}
