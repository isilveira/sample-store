﻿using Store.Core.Domain.Validations.DomainValidations.Default.Samples;
using Store.Core.Domain.Validations.EntityValidations.Default;
using Store.Core.Domain.Validations.Specifications.Default.Samples;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddTransient<PutSampleSpecificationsValidator>();
            services.AddTransient<PostSampleSpecificationsValidator>();
            services.AddTransient<PatchSampleSpecificationsValidator>();
            services.AddTransient<DeleteSampleSpecificationsValidator>();

            return services;
        }
    }
}
