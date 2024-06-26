using AutoMapper;
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
            services.AddTransient<EmailService>();
            services.AddTransient<AuthService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<ITelegramApiHandlerService, TelegramApiHandlerService>();
            services.AddScoped<IPhoneConfirmationService, PhoneConfirmationService>();
        }

        public static void AddMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperUserProfile).Assembly);
        }
    }
}
