using Microsoft.Extensions.DependencyInjection;
using BlockChainStorageApp.Core.Interfaces;
using BlockChainStorageApp.Core.Services;

namespace BlockChainStorageApp.Core
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICryptoService, CryptoService>();
            return services;
        }
    }
}
