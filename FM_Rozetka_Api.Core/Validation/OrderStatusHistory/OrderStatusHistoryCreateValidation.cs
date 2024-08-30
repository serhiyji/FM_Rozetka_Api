using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.Orders.OrderStatusHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Validation.OrderStatusHistory
{
    public class OrderStatusHistoryCreateValidation : AbstractValidator<OrderStatusHistoryCreateDTO>
    {
        public OrderStatusHistoryCreateValidation()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("OrderId is required.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.");

            RuleFor(x => x.ChangedAt)
                .NotEmpty().WithMessage("ChangedAt is required.");
        }
    }
}
