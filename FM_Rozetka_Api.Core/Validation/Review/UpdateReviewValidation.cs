using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Validation.Review
{
    public class UpdateReviewValidation : AbstractValidator<ReviewUpdateDTO>
    {
        public UpdateReviewValidation()
        {
            RuleFor(r => r.Rating).NotEmpty();
            RuleFor(r => r.Comment).NotEmpty().MinimumLength(2).MaximumLength(2048);
        }
    }
}
