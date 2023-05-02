using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.Customers.Services.DeleteCustomer
{
    public class DeleteCustomerServiceRequest : DomainServiceRequest<Customer>
    {
        public DeleteCustomerServiceRequest(Customer payload) : base(payload)
        {
        }
    }
}
