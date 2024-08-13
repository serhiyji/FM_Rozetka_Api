using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.Shops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
