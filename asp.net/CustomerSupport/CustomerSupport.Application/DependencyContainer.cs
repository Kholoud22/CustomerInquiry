using CustomerSupport.Application.Contracts;
using CustomerSupport.Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerSupport.Application
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSingleton<ICacheService, MemoryCacheService>();

            services.AddMediatR(typeof(ApplicationLayer).Assembly);

        }
    }
}
