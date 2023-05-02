using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.Customers.Services.CreateCustomer
{
    public class CreateCustomerServiceRequest : DomainServiceRequest<Customer>
    {
        public CreateCustomerServiceRequest(Customer payload) : base(payload)
        {
        }
    }
}
