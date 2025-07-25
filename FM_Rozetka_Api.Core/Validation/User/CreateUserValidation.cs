﻿using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.User;
using System.Text.RegularExpressions;

namespace FM_Rozetka_Api.Core.Validation.User
{
    public class CreateUserValidation : AbstractValidator<CreateUserDTO>
    {
        public CreateUserValidation()
        {
            RuleFor(r => r.FirstName).MinimumLength(2).NotEmpty().MaximumLength(12);
            RuleFor(r => r.LastName).MinimumLength(2).NotEmpty().MaximumLength(12);
            RuleFor(r => r.SurName).MinimumLength(2).NotEmpty().MaximumLength(12);
            RuleFor(r => r.Email).NotEmpty().WithMessage("Field email must not be empty")
        .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(r => r.PhoneNumber).NotEmpty().MinimumLength(10).MaximumLength(15).WithMessage("Incorect format PhoneNumber");
            RuleFor(r => r.PhoneNumber)
            .NotEmpty().WithMessage("The Phone Number field must be filled.")
            .Must(PhoneNumberValidator).WithMessage("Please enter a valid Ukrainian phone number in the format +380xxxxxxxxx or 0xxxxxxxxx.");
            RuleFor(r => r.Password).NotEmpty().WithMessage("Filed must not be empty")
                 .MinimumLength(6).WithMessage("Password must be at least 6 characters");
            RuleFor(r => r.ConfirmPassword).NotEmpty().WithMessage("Filed must not be empty").
                MinimumLength(6).WithMessage("Password must be at least 6 characters").
                Equal(p => p.Password).WithMessage("The verification password is incorrect");
        }

        private bool PhoneNumberValidator(string phoneNumber)
        {
            if (phoneNumber.StartsWith("+380"))
            {
                return Regex.IsMatch(phoneNumber, @"^\+380\d{9}$");
            }
            else if (phoneNumber.StartsWith("0"))
            {
                return Regex.IsMatch(phoneNumber, @"^0\d{9}$");
            }

            return false;
        }
    }
}
