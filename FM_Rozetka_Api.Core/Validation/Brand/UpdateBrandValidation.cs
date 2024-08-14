using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Validation.Brand
{
    public class UpdateBrandValidation : AbstractValidator<BrandCreateDTO>
    {
        public UpdateBrandValidation()
        {
            RuleFor(item => item.Name).NotEmpty().MaximumLength(256);
            RuleFor(item => item.Description).MaximumLength(1024);
        }
    }
}
