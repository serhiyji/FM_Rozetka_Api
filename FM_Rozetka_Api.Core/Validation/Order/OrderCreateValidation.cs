using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.Orders.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Validation.Order
{
    public class OrderCreateValidation : AbstractValidator<OrderCreateDTO>
    {
        public OrderCreateValidation()
        {
            RuleFor(x => x.AppUserId)
                .NotEmpty().WithMessage("AppUserId is required.");

            RuleFor(x => x.OrderDate)
                .NotEmpty().WithMessage("OrderDate is required.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.");

            RuleFor(x => x.TotalAmount)
                .GreaterThanOrEqualTo(0).WithMessage("TotalAmount must be greater than or equal to zero.");
        }
    }

}
