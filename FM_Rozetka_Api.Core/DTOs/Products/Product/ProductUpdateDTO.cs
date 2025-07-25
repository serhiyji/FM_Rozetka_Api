﻿using Microsoft.AspNetCore.Http;

namespace FM_Rozetka_Api.Core.DTOs.Products.Product
{
    public class ProductUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Stars { get; set; }
        public bool isVerified { get; set; }
        public int Stock { get; set; }
        public int BrandId { get; set; }
        public IFormFile? MainImageFile { get; set; }
        public List<IFormFile>? AdditionalImageFiles { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int ShopId { get; set; }
        public bool HasDiscount { get; set; }
        public int CategoryProductId { get; set; }
        public int CountryProductionId { get; set; }
    }
}
