using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Validation.User
{
    public class LoginUserByPhoneValidation : AbstractValidator<UserLoginPhoneDTO>
    {
        public LoginUserByPhoneValidation() 
        {
            RuleFor(r => r.Phone).NotEmpty().MinimumLength(10).MaximumLength(13).WithMessage("Field must not be empty").WithMessage("Invalid phone format");
            RuleFor(r => r.Password).NotEmpty().WithMessage("Field must not be empty")
                .MinimumLength(6).WithMessage("Password must be at least 6 charters")
                .MaximumLength(128);
        }
    }
}
