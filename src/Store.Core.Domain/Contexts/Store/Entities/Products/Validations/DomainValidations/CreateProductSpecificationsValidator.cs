using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using Store.Core.Domain.Contexts.Store.Entities.Products.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.Products.Validations.DomainValidations
{
    public class CreateProductSpecificationsValidator : DomainValidator<Product>
    {
        public CreateProductSpecificationsValidator()
        {
        }
    }
}
