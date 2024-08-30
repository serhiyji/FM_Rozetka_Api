using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.Orders.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Validation.Payment
{
    public class PaymentCreateValidation : AbstractValidator<PaymentCreateDTO>
    {
        public PaymentCreateValidation()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("OrderId is required.");

            RuleFor(x => x.PaymentMethod)
                .NotEmpty().WithMessage("PaymentMethod is required.")
                .MaximumLength(100).WithMessage("PaymentMethod cannot exceed 100 characters.");

            RuleFor(x => x.PaymentDate)
                .NotEmpty().WithMessage("PaymentDate is required.");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than 0.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .MaximumLength(50).WithMessage("Status cannot exceed 50 characters.");
        }
    }
}
