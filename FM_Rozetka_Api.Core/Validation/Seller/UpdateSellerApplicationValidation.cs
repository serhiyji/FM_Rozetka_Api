using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.Seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Validation.Seller
{
    public class UpdateSellerApplicationValidation : AbstractValidator<UpdateSellerApplicationDTO>
    {
        public UpdateSellerApplicationValidation()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Company Name is required.")
                .MaximumLength(256).WithMessage("Company Name must be less than 256 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format.");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full Name is required.")
                .MaximumLength(256).WithMessage("Full Name must be less than 256 characters.");

            RuleFor(x => x.Position)
                .NotEmpty().WithMessage("Position is required.")
                .MaximumLength(256).WithMessage("Position must be less than 256 characters.");

            RuleFor(x => x.Website)
                .MaximumLength(256).WithMessage("Website must be less than 256 characters.")
                .When(x => !string.IsNullOrEmpty(x.Website));

            RuleFor(x => x.HasNoWebsite)
                .NotNull().WithMessage("HasNoWebsite is required.");
        }
    }
}
