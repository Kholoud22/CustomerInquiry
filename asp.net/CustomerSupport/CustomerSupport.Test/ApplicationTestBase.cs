using CustomerSupport.Application;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace CustomerSupport.Test
{
    public class ApplicationTestBase : IDisposable
    {
        private IServiceScope _serviceScope;

        public ApplicationTestBase()
        {
            SetupApplication();
        }

        protected IServiceProvider Services => _serviceScope.ServiceProvider;

        protected IMediator Mediator => Services.GetRequiredService<IMediator>();

        public Task<TResult> SendAsync<TResult>(IRequest<TResult> request)
        {
            return Mediator.Send(request);
        }

        public void Dispose()
        {
            _serviceScope.Dispose();
        }

        private void SetupApplication()
        {
            var serviceCollection = ConfigureServices();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            _serviceScope = serviceProvider.CreateScope();
        }

        private IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();
            services.RegisterServices();            
            return services;
        }
    }
}
