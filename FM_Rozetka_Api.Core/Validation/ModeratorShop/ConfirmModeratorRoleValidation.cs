using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.Shops.ModeratorShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Validation.ModeratorShop
{
    public class ConfirmModeratorRoleValidation : AbstractValidator<ConfirmModeratorRoleDTO>
    {
        public ConfirmModeratorRoleValidation()
        {
            RuleFor(x => x.ShopId)
               .NotEmpty().WithMessage("ShopId is required.");

            RuleFor(x => x.AppUserId)
             .NotEmpty().WithMessage("AppUserId is required.");

            RuleFor(x => x.token)
           .NotEmpty().WithMessage("token is required.");

        }
    }
}
