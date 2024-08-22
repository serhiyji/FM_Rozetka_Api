using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Validation.Brand
{
    public class UpdateBrandValidation : AbstractValidator<BrandUpdateDTO>
    {
        public UpdateBrandValidation()
        {
            RuleFor(brand => brand.Id)
           .GreaterThan(0).WithMessage("Brand ID must be greater than 0");

            RuleFor(brand => brand.Name)
                .NotEmpty().WithMessage("Brand name cannot be empty")
                .MaximumLength(100).WithMessage("Brand name cannot exceed 100 characters");

            RuleFor(brand => brand.Description)
                .NotEmpty().WithMessage("Brand description cannot be empty")
                .MaximumLength(500).WithMessage("Brand description cannot exceed 500 characters");
        }
    }
}
