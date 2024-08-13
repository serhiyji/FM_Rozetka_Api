using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.User;

namespace FM_Rozetka_Api.Core.Validation.User
{
    public class UpdatePasswordValidation : AbstractValidator<UpdatePasswordDto>
    {
        public UpdatePasswordValidation()
        {
            RuleFor(r => r.OldPassword).MinimumLength(6).NotEmpty();
            RuleFor(r => r.NewPassword).MinimumLength(6).NotEmpty();
            RuleFor(r => r.ConfirmPassword).MinimumLength(6).Equal(r => r.NewPassword).NotEmpty();
        }
    }
}
