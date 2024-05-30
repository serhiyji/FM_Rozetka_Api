using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Address;
using FM_Rozetka_Api.Core.DTOs.Brand;
using FM_Rozetka_Api.Core.DTOs.Cart;
using FM_Rozetka_Api.Core.DTOs.CartItem;
using FM_Rozetka_Api.Core.DTOs.CategoryProduct;
using FM_Rozetka_Api.Core.DTOs.CountryProduction;
using FM_Rozetka_Api.Core.DTOs.CountryProductionProduct;
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

            // Cart
            CreateMap<Cart, CartCreateDTO>();
            CreateMap<Cart, CartUpdateDTO>();
            CreateMap<Cart, CartDTO>();

            // CartItem
            CreateMap<CartItem, CartItemCreateDTO>();
            CreateMap<CartItem, CartItemUpdateDTO>();
            CreateMap<CartItem, CartItemDTO>();

            // CategoryProduct
            CreateMap<CategoryProduct, CategoryProductCreateDTO>();
            CreateMap<CategoryProduct, CategoryProductUpdateDTO>();
            CreateMap<CategoryProduct, CategoryProductDTO>();

            // CountryProduction
            CreateMap<CountryProduction, CountryProductionCreateDTO>();
            CreateMap<CountryProduction, CountryProductionUpdateDTO>();
            CreateMap<CountryProduction, CountryProductionDTO>();

            // CountryProductionProduct
            CreateMap<CountryProductionProduct, CountryProductionProductCreateDTO>();
            CreateMap<CountryProductionProduct, CountryProductionProductUpdateDTO>();
            CreateMap<CountryProductionProduct, CountryProductionProductDTO>();

            // Discount
            CreateMap<Discount, DiscountCreateDTO>();
            CreateMap<Discount, DiscountUpdateDTO>();
            CreateMap<Discount, DiscountDTO>();

            // Favorite
            CreateMap<Favorite, FavoriteCreateDTO>();
            CreateMap<Favorite, FavoriteUpdateDTO>();
            CreateMap<Favorite, FavoriteDTO>();

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

            // ProductBrand
            CreateMap<ProductBrand, ProductBrandCreateDTO>();
            CreateMap<ProductBrand, ProductBrandUpdateDTO>();
            CreateMap<ProductBrand, ProductBrandDTO>();

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

            // Review
            CreateMap<Review, ReviewCreateDTO>();
            CreateMap<Review, ReviewUpdateDTO>();
            CreateMap<Review, ReviewDTO>();

            // ModeratorShop
            CreateMap<ModeratorShop, ModeratorShopCreateDTO>();
            CreateMap<ModeratorShop, ModeratorShopUpdateDTO>();
            CreateMap<ModeratorShop, ModeratorShopDTO>();

            // Shop
            CreateMap<Shop, ShopCreateDTO>();
            CreateMap<Shop, ShopUpdateDTO>();
            CreateMap<Shop, ShopDTO>();

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
