using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.Shops.ModeratorShop;
using FM_Rozetka_Api.Core.DTOs.Shops.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Validation.ModeratorShop
{
    public class ModeratorShopCreateValidation : AbstractValidator<ModeratorShopCreateDTO>
    {
        public ModeratorShopCreateValidation()
        {
            RuleFor(x => x.ShopId)
               .NotEmpty().WithMessage("ShopId is required.");

            RuleFor(x => x.AppUserId)
             .NotEmpty().WithMessage("AppUserId is required.");

        }
    }
}
