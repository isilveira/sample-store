using Store.Core.Domain.Interfaces.Services.Default.Samples;
using Store.Core.Domain.Services.Default.Samples;
using Microsoft.Extensions.DependencyInjection;

namespace Store.Middleware.AddServices
{
    public static class AddDomainServicesConfigurations
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IPutSampleService, PutSampleService>();
            services.AddTransient<IPostSampleService, PostSampleService>();
            services.AddTransient<IPatchSampleService, PatchSampleService>();
            services.AddTransient<IDeleteSampleService, DeleteSampleService>();

            return services;
        }
    }
}
