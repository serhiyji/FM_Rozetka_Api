using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.OrderItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Validation.OrderItem
{
    public class OrderItemUpdateValidation : AbstractValidator<OrderItemUpdateDTO>
    {
        public OrderItemUpdateValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than zero.");

            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("OrderId is required.")
                .GreaterThan(0).WithMessage("OrderId must be greater than zero.");

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId is required.")
                .GreaterThan(0).WithMessage("ProductId must be greater than zero.");

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Quantity is required.")
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price is required.")
                .GreaterThan(0).WithMessage("Price must be greater than zero.");
        }
    }
}
