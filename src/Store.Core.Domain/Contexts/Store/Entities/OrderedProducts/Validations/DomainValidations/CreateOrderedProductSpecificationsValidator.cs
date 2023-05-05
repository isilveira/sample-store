using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Validations.DomainValidations
{
    public class CreateOrderedProductSpecificationsValidator : DomainValidator<OrderedProduct>
    {
        public CreateOrderedProductSpecificationsValidator()
        {
        }
    }
}
