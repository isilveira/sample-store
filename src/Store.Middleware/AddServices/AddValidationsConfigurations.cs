using Microsoft.Extensions.DependencyInjection;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Validations.DomainValidations;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Validations.EntityValidations.Default;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Validations.Specifications.Default.Samples;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Validations.DomainValidations;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Validations.EntityValidations;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Specifications;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Validations.DomainValidations;
using Store.Core.Domain.Contexts.Store.Entities.Images.Validations.DomainValidations;
using Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Validations.DomainValidations;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Validations.DomainValidations;
using Store.Core.Domain.Contexts.Store.Entities.Products.Validations.DomainValidations;
using Store.Core.Domain.Validations.EntityValidations.Default;

namespace Store.Middleware.AddServices
{
    public static class AddValidationsConfigurations
    {
        public static IServiceCollection AddSpecifications(this IServiceCollection services)
        {
            services.AddTransient<SampleDescriptionAlreadyExistsSpecification>();

            services.AddTransient<CustomerEmailMustBeUniqueSpecification>();

            return services;
        }
        public static IServiceCollection AddEntityValidations(this IServiceCollection services)
        {
            services.AddTransient<SampleValidator>();

            services.AddTransient<CategoryValidator>();
            services.AddTransient<CustomerValidator>();
            services.AddTransient<ImageValidator>();
            services.AddTransient<OrderValidator>();
            services.AddTransient<OrderedProductValidator>();
            services.AddTransient<ProductValidator>();

            return services;
        }
        public static IServiceCollection AddDomainValidations(this IServiceCollection services)
        {
            services.AddTransient<CreateCategorySpecificationsValidator>();
            services.AddTransient<DeleteCategorySpecificationsValidator>();
            services.AddTransient<UpdateCategorySpecificationsValidator>();

            services.AddTransient<CreateCustomerSpecificationsValidator>();
            services.AddTransient<DeleteCustomerSpecificationsValidator>();
            services.AddTransient<UpdateCustomerSpecificationsValidator>();

            services.AddTransient<CreateImageSpecificationsValidator>();
            services.AddTransient<DeleteImageSpecificationsValidator>();
            services.AddTransient<UpdateImageSpecificationsValidator>();

            services.AddTransient<CreateOrderSpecificationsValidator>();
            services.AddTransient<DeleteOrderSpecificationsValidator>();
            services.AddTransient<UpdateOrderSpecificationsValidator>();

            services.AddTransient<CreateOrderedProductSpecificationsValidator>();
            services.AddTransient<DeleteOrderedProductSpecificationsValidator>();
            services.AddTransient<UpdateOrderedProductSpecificationsValidator>();

            services.AddTransient<CreateProductSpecificationsValidator>();
            services.AddTransient<DeleteProductSpecificationsValidator>();
            services.AddTransient<UpdateProductSpecificationsValidator>();

            services.AddTransient<CreateSampleSpecificationsValidator>();
            services.AddTransient<DeleteSampleSpecificationsValidator>();
            services.AddTransient<UpdateSampleSpecificationsValidator>();

            return services;
        }
    }
}
