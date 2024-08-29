using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Address;
using FM_Rozetka_Api.Core.DTOs.Brand;
using FM_Rozetka_Api.Core.DTOs.CartItem;
using FM_Rozetka_Api.Core.DTOs.CategoryProduct;
using FM_Rozetka_Api.Core.DTOs.Company;
using FM_Rozetka_Api.Core.DTOs.CountryProduction;
using FM_Rozetka_Api.Core.DTOs.Discount;
using FM_Rozetka_Api.Core.DTOs.Favorite;
using FM_Rozetka_Api.Core.DTOs.OrderItem;
using FM_Rozetka_Api.Core.DTOs.Orders.Order;
using FM_Rozetka_Api.Core.DTOs.Orders.OrderStatusHistory;
using FM_Rozetka_Api.Core.DTOs.Orders.Payment;
using FM_Rozetka_Api.Core.DTOs.Orders.Shipment;
using FM_Rozetka_Api.Core.DTOs.ProductBrand;
using FM_Rozetka_Api.Core.DTOs.Products.PhotoProduct;
using FM_Rozetka_Api.Core.DTOs.Products.Product;
using FM_Rozetka_Api.Core.DTOs.Products.ProductAnswer;
using FM_Rozetka_Api.Core.DTOs.Products.ProductQuestion;
using FM_Rozetka_Api.Core.DTOs.Review;
using FM_Rozetka_Api.Core.DTOs.Seller;
using FM_Rozetka_Api.Core.DTOs.Shops.ModeratorShop;
using FM_Rozetka_Api.Core.DTOs.Shops.Shop;
using FM_Rozetka_Api.Core.DTOs.Specifications.CategorySpecification;
using FM_Rozetka_Api.Core.DTOs.Specifications.Specification;
using FM_Rozetka_Api.Core.Entities;
using Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Adress
            CreateMap<Adress, AddressCreateDTO>();
            CreateMap<Adress, AddressUpdateDTO>();
            CreateMap<Adress, AddressDTO>();

            // Brand
            CreateMap<Brand, BrandCreateDTO>();
            CreateMap<Brand, BrandUpdateDTO>();
            CreateMap<Brand, BrandDTO>();

            // CartItem
            CreateMap<CartItem, CartItemCreateDTO>().ReverseMap();
            CreateMap<CartItem, CartItemUpdateDTO>().ReverseMap();
            CreateMap<CartItem, CartItemDTO>().ReverseMap();

            // CategoryProduct
            CreateMap<CategoryProduct, CategoryProductCreateDTO>().ReverseMap(); 
            CreateMap<CategoryProduct, CategoryProductUpdateDTO>().ReverseMap();
            CreateMap<CategoryProduct, CategoryProductDTO>().ReverseMap();
            CreateMap<CategoryProductCreateDTO, CategoryProduct>().ReverseMap();

            // CountryProduction
            CreateMap<CountryProduction, CountryProductionCreateDTO>().ReverseMap();
            CreateMap<CountryProduction, CountryProductionUpdateDTO>().ReverseMap();
            CreateMap<CountryProduction, CountryProductionDTO>().ReverseMap();

            // Discount
            CreateMap<Discount, DiscountCreateDTO>().ReverseMap();
            CreateMap<Discount, DiscountUpdateDTO>().ReverseMap();
            CreateMap<Discount, DiscountDTO>().ReverseMap();

            // Favorite
            CreateMap<Favorite, FavoriteCreateDTO>();
            CreateMap<Favorite, FavoriteDTO>().ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product));

            // OrderItem
            CreateMap<OrderItem, OrderItemCreateDTO>();
            CreateMap<OrderItem, OrderItemUpdateDTO>();
            CreateMap<OrderItem, OrderItemDTO>();

            // Order
            CreateMap<Order, OrderCreateDTO>();
            CreateMap<Order, OrderUpdateDTO>();
            CreateMap<Order, OrderDTO>();

            // OrderStatusHistory
            CreateMap<OrderStatusHistory, OrderStatusHistoryCreateDTO>();
            CreateMap<OrderStatusHistory, OrderStatusHistoryUpdateDTO>();
            CreateMap<OrderStatusHistory, OrderStatusHistoryDTO>();

            // Payment
            CreateMap<Payment, PaymentCreateDTO>();
            CreateMap<Payment, PaymentUpdateDTO>();
            CreateMap<Payment, PaymentDTO>();

            // Shipment
            CreateMap<Shipment, ShipmentCreateDTO>();
            CreateMap<Shipment, ShipmentUpdateDTO>();
            CreateMap<Shipment, ShipmentDTO>();

            // PhotoProduct
            CreateMap<PhotoProduct, PhotoProductCreateDTO>().ReverseMap();
            CreateMap<PhotoProduct, PhotoProductUpdateDTO>().ReverseMap();
            CreateMap<PhotoProduct, PhotoProductDTO>().ReverseMap();

            // Product
            CreateMap<Product, ProductCreateDTO>().ReverseMap();
            CreateMap<Product, ProductUpdateDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();

            // ProductAnswer
            CreateMap<ProductAnswer, ProductAnswerCreateDTO>().ReverseMap();
            CreateMap<ProductAnswer, ProductAnswerUpdateDTO>().ReverseMap();
            CreateMap<ProductAnswer, ProductAnswerDTO>().ReverseMap();

            // ProductQuestion
            CreateMap<ProductQuestion, ProductQuestionCreateDTO>().ReverseMap();
            CreateMap<ProductQuestion, ProductQuestionUpdateDTO>().ReverseMap();
            CreateMap<ProductQuestion, ProductQuestionDTO>().ReverseMap();

            // Review
            CreateMap<Review, ReviewCreateDTO>();
            CreateMap<Review, ReviewUpdateDTO>();
            CreateMap<Review, ReviewDTO>();

            // ModeratorShop
            CreateMap<ModeratorShop, ModeratorShopCreateDTO>().ReverseMap();
            CreateMap<ModeratorShop, ModeratorShopUpdateDTO>().ReverseMap();
            CreateMap<ModeratorShop, ModeratorShopDTO>().ReverseMap();

            // Shop
            CreateMap<Shop, ShopCreateDTO>().ReverseMap();
            CreateMap<Shop, ShopUpdateDTO>().ReverseMap();
            CreateMap<Shop, ShopDTO>().ReverseMap();
            CreateMap<SellerApplicationDTO, ShopCreateDTO>().ReverseMap();


            // CategorySpecification
            CreateMap<CategorySpecification, CategorySpecificationCreateDTO>();
            CreateMap<CategorySpecification, CategorySpecificationUpdateDTO>();
            CreateMap<CategorySpecification, CategorySpecificationDTO>();

            // Specification
            CreateMap<Specification, SpecificationCreateDTO>();
            CreateMap<Specification, SpecificationUpdateDTO>();
            CreateMap<Specification, SpecificationDTO>();

            // SellerApplication
            CreateMap<SellerApplication, SellerApplicationDTO>().ReverseMap();
            CreateMap<CreateSellerApplicationDTO, SellerApplication>().ReverseMap();
            CreateMap<UpdateSellerApplicationDTO, SellerApplication>().ReverseMap();
            CreateMap<SellerApplicationDTO, UpdateSellerApplicationDTO>().ReverseMap();

            //Company
            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<CreateCompanyDTO, Company>().ReverseMap();
            CreateMap<UpdateCompanyDTO, Company>().ReverseMap();

            //Review
            CreateMap<Review, ReviewDTO>().ReverseMap();
            CreateMap<ReviewCreateDTO, Review>().ReverseMap();
            CreateMap<ReviewUpdateDTO, Review>().ReverseMap();
        }
    }
}
