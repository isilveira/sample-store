using Microsoft.Extensions.DependencyInjection;

namespace Store.Middleware.AddServices
{
    public static class AddDomainServicesConfigurations
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
