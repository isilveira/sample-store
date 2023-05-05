using BAYSOFT.Abstractions.Core.Application;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Entity;

namespace Store.Core.Application.Contexts.Store.Customers.Queries.GetCustomersByFilter
{
    public class GetCustomersByFilterQuery : ApplicationRequest<Customer, GetCustomersByFilterQueryResponse>
    {
        public GetCustomersByFilterQuery()
        {
            ConfigKeys(x => x.Id);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Orders);

            ConfigSuppressedResponseProperties(x => x.Orders);
        }
    }
}
