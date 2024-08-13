using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.Shops.ModeratorShop;

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
