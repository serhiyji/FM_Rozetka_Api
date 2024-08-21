using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.User;

namespace FM_Rozetka_Api.Core.Validation.User
{
    public class EditUserValidation : AbstractValidator<EditUserDTO>
    {
        public EditUserValidation()
        {
            RuleFor(r => r.FirstName).MinimumLength(2).NotEmpty().MaximumLength(12);
            RuleFor(r => r.LastName).MinimumLength(2).NotEmpty().MaximumLength(12);
            RuleFor(r => r.SurName).MinimumLength(2).NotEmpty().MaximumLength(12);
        }
    }
}
