using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.Customers.Services.UpdateCustomer
{
    public class UpdateCustomerServiceRequest : DomainServiceRequest<Customer>
    {
        public UpdateCustomerServiceRequest(Customer payload) : base(payload)
        {
        }
    }
}
