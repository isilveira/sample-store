using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.Customers.Validations.DomainValidations
{
    public class DeleteCustomerSpecificationsValidator : DomainValidator<Customer>
    {
        public DeleteCustomerSpecificationsValidator()
        {
        }
    }
}
