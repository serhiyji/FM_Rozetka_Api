using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.Orders.Shipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Validation.Shipment
{
    public class ShipmentUpdateValidation : AbstractValidator<ShipmentUpdateDTO>
    {
        public ShipmentUpdateValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");

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

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(x => x.SurName)
                .NotEmpty().WithMessage("SurName is required.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Region)
                .NotEmpty().WithMessage("Region is required.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.");

            RuleFor(x => x.PickupPoint)
                .NotEmpty().WithMessage("PickupPoint is required.");
        }
    }
}
