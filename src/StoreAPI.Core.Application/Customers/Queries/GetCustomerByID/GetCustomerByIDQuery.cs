using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;

namespace StoreAPI.Core.Application.Customers.Queries.GetCustomerByID
{
    public class GetCustomerByIDQuery : RequestBase<Customer, GetCustomerByIDQueryResponse>
    {
        public GetCustomerByIDQuery()
        {
            ConfigKeys(x => x.CustomerID);

            ConfigSuppressedProperties(x => x.Orders);

            ConfigSuppressedResponseProperties(x => x.Orders);
        }
    }
}
