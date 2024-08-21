using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.Products.Product;
using FM_Rozetka_Api.Core.DTOs.Products.ProductQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Validation.Product
{
    public class ProductQuestionCreateValidation: AbstractValidator<ProductQuestionCreateDTO>
    {
        public ProductQuestionCreateValidation()
        {
            RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("ProductId must be greater than 0.");

            RuleFor(x => x.AppUserId)
                .NotEmpty().WithMessage("AppUserId cannot be empty.");

            RuleFor(x => x.QuestionText)
                .NotEmpty().WithMessage("QuestionText cannot be empty.")
                .MaximumLength(500).WithMessage("QuestionText cannot exceed 500 characters.");

            RuleFor(x => x.CreatedAt)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("CreatedAt cannot be in the future.");

        }
    }
}
