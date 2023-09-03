using Store.Core.Domain.Interfaces.Infrastructures.Services;
using Store.Infrastructures.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Store.Middleware.AddServices
{
    public static class AddDomainServicesConfigurations
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}