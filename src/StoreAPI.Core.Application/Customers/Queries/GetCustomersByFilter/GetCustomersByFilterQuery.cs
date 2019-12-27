using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;

namespace StoreAPI.Core.Application.Customers.Queries.GetCustomersByFilter
{
    public class GetCustomersByFilterQuery : RequestBase<Customer, GetCustomersByFilterQueryResponse>
    {
        public GetCustomersByFilterQuery()
        {
            ConfigKeys(x => x.CustomerID);

            ConfigSuppressedProperties(x => x.Orders);

            ConfigSuppressedResponseProperties(x => x.Orders);
        }
    }
}
