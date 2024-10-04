using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.Orders.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Validation.Order
{
    public class OrderUpdateValidation : AbstractValidator<OrderUpdateDTO>
    {
        public OrderUpdateValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(x => x.AppUserId)
                .NotEmpty().WithMessage("AppUserId is required.");

            RuleFor(x => x.OrderDate)
                .NotEmpty().WithMessage("OrderDate is required.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.");

            RuleFor(x => x.TotalAmount).NotEmpty().WithMessage("TotalAmount is required.")
                .GreaterThan(0).WithMessage("TotalAmount must be greater than or equal to zero.");
        }
    }

}
