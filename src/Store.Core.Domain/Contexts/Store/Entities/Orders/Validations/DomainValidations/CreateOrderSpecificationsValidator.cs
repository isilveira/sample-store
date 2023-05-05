using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.Orders.Validations.DomainValidations
{
    public class CreateOrderSpecificationsValidator : DomainValidator<Order>
    {
        public CreateOrderSpecificationsValidator()
        {
        }
    }
}
