﻿using Store.Middleware.AddServices;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelWrapper.Middleware;
using System;
using System.Reflection;

namespace Store.Middleware
{
    public static class Configurations
    {
        public static IServiceCollection AddMiddleware(this IServiceCollection services, IConfiguration configuration, Assembly presentationAssembly)
        {
            services.AddLocalization();

            services.AddDbContexts(configuration);
            services.AddSpecifications();
            services.AddEntityValidations();
            services.AddDomainValidations();
            services.AddDomainServices();

            var assembly = AppDomain.CurrentDomain.Load("Store.Core.Application");


            var assemblyApplication = AppDomain.CurrentDomain.Load("Store.Core.Application");
            var assemblyDomain = AppDomain.CurrentDomain.Load("Store.Core.Domain");
            services.AddMediatR(options => options.RegisterServicesFromAssemblies(assemblyApplication, assemblyDomain));

            services.AddModelWrapper()
                .AddDefaultReturnedCollectionSize(10)
                .AddMinimumReturnedCollectionSize(1)
                .AddMaximumReturnedCollectionSize(100)
                .AddQueryTermsMinimumSize(3)
                .AddSuppressedTerms(new string[] { "the" });

            // YOUR CODE GOES HERE
            return services;
        }

        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder app)
        {
            var supportedCultures = new string[] { "en-US", "pt-BR" };

            var localizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);
            
            app.UseRequestLocalization(localizationOptions);

            //app.UseAuthentication();
            //app.UseAuthorization();
            // YOUR CODE GOES HERE
            return app;
        }
    }
}
