using AutoBet.Domain.ViewModels;
using AutoBet.Services;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AutoBet.App.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AppMappingProfile>());
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<AuthViewModel>();
            services.AddSingleton<CertificateViewModel>();
            services.AddSingleton<HomeViewModel>();

            return services;
        }
    }
}
