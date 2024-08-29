using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.CartItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Validation.CartItem
{
    public class CartItemUpdateValidation : AbstractValidator<CartItemUpdateDTO>
    {
        public CartItemUpdateValidation()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.AppUserId)
                .NotEmpty().WithMessage("AppUserId cannot be empty.");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }
    }
}
