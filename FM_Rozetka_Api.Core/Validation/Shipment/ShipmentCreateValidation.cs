using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.Orders.Shipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Validation.Shipment
{
    public class ShipmentCreateValidation : AbstractValidator<ShipmentCreateDTO>
    {
        public ShipmentCreateValidation()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("OrderId is required.");

            RuleFor(x => x.ShipmentDate)
                .NotEmpty().WithMessage("ShipmentDate is required.");

            RuleFor(x => x.TrackingNumber)
                .NotEmpty().WithMessage("TrackingNumber is required.")
                .MaximumLength(50).WithMessage("TrackingNumber cannot exceed 50 characters.");

            RuleFor(x => x.Carrier)
                .NotEmpty().WithMessage("Carrier is required.")
                .MaximumLength(100).WithMessage("Carrier cannot exceed 100 characters.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.");
        }
    }
}
