using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Validation.User
{
    public class RegistrationUserValidation : AbstractValidator<RegistrationUserDTO>
    {
        public RegistrationUserValidation()
        {
            RuleFor(r => r.Email).NotEmpty().WithMessage("Field email must not be empty")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(r => r.Password).NotEmpty().WithMessage("Field password must not be empty");
            RuleFor(r => r.ConfirmPassword)
                .NotEmpty().WithMessage("Field confirm password must not be empty")
                .Equal(r => r.Password).WithMessage("Passwords do not match");
        }
    }
}
