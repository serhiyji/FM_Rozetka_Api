using FluentValidation;
using FM_Rozetka_Api.Core.DTOs.Products.Product;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Validation.Product
{
    public class CreateProductValidation : AbstractValidator<ProductCreateDTO>
    {
        public CreateProductValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Product name cannot exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(x => x.Stars)
                .InclusiveBetween(0, 5).WithMessage("Stars must be between 0 and 5.");

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Stock cannot be negative.");

            RuleFor(x => x.ShopId)
                .GreaterThan(0).WithMessage("ShopId is required.");

            RuleFor(x => x.CategoryProductId)
                .GreaterThan(0).WithMessage("CategoryProductId is required.");

            RuleFor(x => x.CountryProductionId)
                .GreaterThan(0).WithMessage("CountryProductionId is required.");

            RuleFor(x => x.MainImageFile)
                .Must(BeAValidImage).WithMessage("Invalid image file format.")
                .When(x => x.MainImageFile != null);

            RuleForEach(x => x.AdditionalImageFiles)
                .Must(BeAValidImage).WithMessage("Invalid image file format.")
                .When(x => x.AdditionalImageFiles != null);

            RuleFor(x => x.AdditionalImageFiles)
                .Must(files => files == null || files.Count() <= 15)
                .WithMessage("The number of additional images cannot exceed 15.");
        }

        private bool BeAValidImage(IFormFile file)
        {
            var validExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };
            var extension = Path.GetExtension(file.FileName);
            return validExtensions.Contains(extension.ToLower());
        }
    }

}
