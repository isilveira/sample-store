using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Entity;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Specifications;

namespace Store.Core.Domain.Contexts.Store.Entities.Customers.Validations.DomainValidations
{
    public class UpdateCustomerSpecificationsValidator : DomainValidator<Customer>
    {
        public UpdateCustomerSpecificationsValidator(
            CustomerEmailMustBeUniqueSpecification customerEmailMustBeUniqueSpecification
        )
        {
            Add("customerEmailMustBeUniqueSpecification", new DomainRule<Customer>(customerEmailMustBeUniqueSpecification.Not(), customerEmailMustBeUniqueSpecification.ToString()));
        }
    }
}
