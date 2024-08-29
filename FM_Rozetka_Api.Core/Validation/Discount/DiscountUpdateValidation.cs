using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Validation.Discount
{
    public class DiscountUpdateValidation : AbstractValidator<DiscountUpdateDTO>
    {
        public DiscountUpdateValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Discount ID is required.");

            RuleFor(x => x.DiscountPercent)
                .GreaterThan(0).WithMessage("Percentage must be greater than 0.")
                .LessThanOrEqualTo(100).WithMessage("Percentage cannot be more than 100.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start date is required.")
                .LessThan(x => x.EndDate).WithMessage("Start date must be before end date.");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End date is required.");

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product ID is required.");
        }
    }
}
