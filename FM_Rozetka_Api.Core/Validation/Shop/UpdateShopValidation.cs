using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.Shops.Shop;

namespace FM_Rozetka_Api.Core.Validation.Shop
{
    public class UpdateShopValidation : AbstractValidator<ShopUpdateDTO>
    {
        public UpdateShopValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number is required.")
                .Matches(x => x.IsNonResident ? @"^\+?[1-9]\d{1,14}$" : @"^380\d{9}$")
                .WithMessage("Invalid phone number format.");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full Name is required.")
                .MaximumLength(256).WithMessage("Full Name must be less than 256 characters.");

            RuleFor(x => x.Position)
                .NotEmpty().WithMessage("Position is required.")
                .MaximumLength(256).WithMessage("Position must be less than 256 characters.");

            RuleFor(x => x.Website)
                .MaximumLength(256).WithMessage("Website must be less than 256 characters.")
                .When(x => !x.HasNoWebsite)
                .WithMessage("Website is required if 'HasNoWebsite' is false.");

            RuleFor(x => x.HasNoWebsite)
                .NotNull().WithMessage("HasNoWebsite is required.")
                .Must((dto, hasNoWebsite) => hasNoWebsite || !string.IsNullOrEmpty(dto.Website))
                .WithMessage("Website must be provided if 'HasNoWebsite' is false.");
        }


    }
}
