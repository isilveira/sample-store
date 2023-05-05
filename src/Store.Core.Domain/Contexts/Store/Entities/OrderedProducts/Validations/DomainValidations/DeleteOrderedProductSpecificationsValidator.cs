using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Validations.DomainValidations
{
    public class DeleteOrderedProductSpecificationsValidator : DomainValidator<OrderedProduct>
    {
        public DeleteOrderedProductSpecificationsValidator()
        {
        }
    }
}
