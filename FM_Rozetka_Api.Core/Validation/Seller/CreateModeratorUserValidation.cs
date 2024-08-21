using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.Shops;

namespace FM_Rozetka_Api.Core.Validation.Seller
{
    public class CreateModeratorUserValidation: AbstractValidator<CreateModeratorUserDTO>
    {
        public CreateModeratorUserValidation()
        {
            RuleFor(r => r.ShopId).NotEmpty();
            RuleFor(r => r.Email).NotEmpty().WithMessage("Field email must not be empty")
       .EmailAddress().WithMessage("Invalid email format.");
        }
    }
}
