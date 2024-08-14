using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.Review;

namespace FM_Rozetka_Api.Core.Validation.Review
{
    public class CreateReviewValidation : AbstractValidator<ReviewCreateDTO>
    {
        public CreateReviewValidation()
        {
            RuleFor(r => r.Rating).NotEmpty();
            RuleFor(r => r.Comment).NotEmpty().MinimumLength(2).MaximumLength(2048);
        }
    }
}
