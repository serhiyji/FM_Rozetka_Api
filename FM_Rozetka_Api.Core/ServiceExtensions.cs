using AutoMapper;
using FluentValidation.AspNetCore;
using FluentValidation;
using FM_Rozetka_Api.Core.AutoMappers;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using FM_Rozetka_Api.Core.Services.Quarz;



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
            services.AddScoped<ICartItemService, CartItemService>();
            services.AddScoped<ICountryProductionService, CountryProductionService>();
            services.AddScoped<IPhotoProductService, PhotoProductService>();
            services.AddScoped<IFilesService, FilesService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductQuestionService, ProductQuestionService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IProductAnswerService, ProductAnswerService>();
            services.AddScoped<IFavoriteService, FavoriteService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IProductQuestionService, ProductQuestionService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IOrderStatusHistoryService, OrderStatusHistoryService>();
            services.AddScoped<IShipmentService, ShipmentService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<INovaPoshtaService, NovaPoshtaService>();
            services.AddScoped<IViewedProductService, ViewedProductService>();
            services.AddTransient<LiqPayService>();
        }

        public static void AddValidator(this IServiceCollection service)
        {
            service.AddFluentValidationAutoValidation();
            service.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void AddMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperUserProfile).Assembly);
            services.AddAutoMapper(typeof(NovaPostProfile).Assembly);
        }

        public static void AddQuartzServices(this IServiceCollection services)
        {
            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory();

                var jobKey = new JobKey("UpdateDiscountJob");
                q.AddJob<UpdateDiscountJob>(opts => opts.WithIdentity(jobKey));
                q.AddTrigger(opts => opts
                    .ForJob(jobKey)
                    .WithIdentity("UpdateDiscountJob-trigger")
                    .WithCronSchedule("0 0 * * * ?")); 
            });

            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
        }
    }
}
