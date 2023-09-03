using Microsoft.Extensions.DependencyInjection;
using Store.Core.Domain.Default.Samples.Specifications;
using Store.Core.Domain.Default.Samples.Validations.DomainValidations;
using Store.Core.Domain.Default.Samples.Validations.EntityValidations;

namespace Store.Middleware.AddServices
{
    public static class AddValidationsConfigurations
    {
        public static IServiceCollection AddSpecifications(this IServiceCollection services)
        {
            services.AddTransient<SampleDescriptionAlreadyExistsSpecification>();

            return services;
        }
        public static IServiceCollection AddEntityValidations(this IServiceCollection services)
        {
            services.AddTransient<SampleValidator>();

            return services;
        }
        public static IServiceCollection AddDomainValidations(this IServiceCollection services)
        {
            services.AddTransient<CreateSampleSpecificationsValidator>();
			services.AddTransient<UpdateSampleSpecificationsValidator>();
			services.AddTransient<DeleteSampleSpecificationsValidator>();

            return services;
        }
    }
}