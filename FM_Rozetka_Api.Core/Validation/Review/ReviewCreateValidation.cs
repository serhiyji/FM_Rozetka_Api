using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Validation.Review
{
    public class ReviewCreateValidation : AbstractValidator<ReviewCreateDTO>
    {
        public ReviewCreateValidation()
        {
            RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("ProductId is required.");

            RuleFor(x => x.AppUserId)
                .NotEmpty().WithMessage("AppUserId is required.");

            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");

            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Comment is required.")
                .MaximumLength(500).WithMessage("Comment cannot be longer than 500 characters.");
        }
    }
}
