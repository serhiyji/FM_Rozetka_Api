using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.CartItem;
using FM_Rozetka_Api.Core.DTOs.CategoryProduct;
using FM_Rozetka_Api.Core.DTOs.Discount;
using FM_Rozetka_Api.Core.DTOs.Favorite;
using FM_Rozetka_Api.Core.DTOs.Products.PhotoProduct;
using FM_Rozetka_Api.Core.DTOs.Products.Product;
using FM_Rozetka_Api.Core.DTOs.Products.ProductAnswer;
using FM_Rozetka_Api.Core.DTOs.Products.ProductQuestion;
using FM_Rozetka_Api.Core.DTOs.Specifications.CategorySpecification;
using FM_Rozetka_Api.Core.DTOs.Specifications.Specification;
using FM_Rozetka_Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CartItem
            CreateMap<CartItem, CartItemCreateDTO>();
            CreateMap<CartItem, CartItemUpdateDTO>();
            CreateMap<CartItem, CartItemDTO>();

            // CategoryProduct
            CreateMap<CategoryProduct, CategoryProductCreateDTO>();
            CreateMap<CategoryProduct, CategoryProductUpdateDTO>();
            CreateMap<CategoryProduct, CategoryProductDTO>();

            // Discount
            CreateMap<Discount, DiscountCreateDTO>();
            CreateMap<Discount, DiscountUpdateDTO>();
            CreateMap<Discount, DiscountDTO>();

            // Favorite
            CreateMap<Favorite, FavoriteCreateDTO>();
            CreateMap<Favorite, FavoriteUpdateDTO>();
            CreateMap<Favorite, FavoriteDTO>();

            // PhotoProduct
            CreateMap<PhotoProduct, PhotoProductCreateDTO>();
            CreateMap<PhotoProduct, PhotoProductUpdateDTO>();
            CreateMap<PhotoProduct, PhotoProductDTO>();

            // Product
            CreateMap<Product, ProductCreateDTO>();
            CreateMap<Product, ProductUpdateDTO>();
            CreateMap<Product, ProductDTO>();

            // ProductAnswer
            CreateMap<ProductAnswer, ProductAnswerCreateDTO>();
            CreateMap<ProductAnswer, ProductAnswerUpdateDTO>();
            CreateMap<ProductAnswer, ProductAnswerDTO>();

            // ProductQuestion
            CreateMap<ProductQuestion, ProductQuestionCreateDTO>();
            CreateMap<ProductQuestion, ProductQuestionUpdateDTO>();
            CreateMap<ProductQuestion, ProductQuestionDTO>();

            // CategorySpecification
            CreateMap<CategorySpecification, CategorySpecificationCreateDTO>();
            CreateMap<CategorySpecification, CategorySpecificationUpdateDTO>();
            CreateMap<CategorySpecification, CategorySpecificationDTO>();

            // Specification
            CreateMap<Specification, SpecificationCreateDTO>();
            CreateMap<Specification, SpecificationUpdateDTO>();
            CreateMap<Specification, SpecificationDTO>();
        }
    }
}
