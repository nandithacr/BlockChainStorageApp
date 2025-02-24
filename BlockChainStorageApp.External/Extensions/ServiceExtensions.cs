using Microsoft.Extensions.DependencyInjection;
using BlockChainStorageApp.Core.Interfaces;
using BlockChainStorageApp.External.Services;

namespace BlockChainStorageApp.External
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddHttpClient<IBlockCypherClient, BlockCypherClient>();
            return services;
        }
    }
}
