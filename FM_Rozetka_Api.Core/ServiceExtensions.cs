using AutoMapper;
using FluentValidation.AspNetCore;
using FluentValidation;
using FM_Rozetka_Api.Core.AutoMappers;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FM_Rozetka_Api.Core
{
    public static class ServiceExtensions
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<ITelegramApiHandlerService, TelegramApiHandlerService>();
            services.AddScoped<IPhoneConfirmationService, PhoneConfirmationService>();
            services.AddScoped<ITelegramUserService, TelegramUserService>();
            services.AddScoped<ISellerService, SellerService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICategoryProductService, CategoryProductService>();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IModeratorShopService, ModeratorShopService>();
        }

        public static void AddValidator(this IServiceCollection service)
        {
            service.AddFluentValidationAutoValidation();
            service.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void AddMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperUserProfile).Assembly);
        }
    }
}
