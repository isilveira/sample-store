using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;

namespace StoreAPI.Core.Application.Customers.Commands.PostCustomer
{
    public class PostCustomerCommand : RequestBase<Customer, PostCustomerCommandResponse>
    {
        public PostCustomerCommand()
        {
            ConfigKeys(x => x.CustomerID);

            ConfigSuppressedProperties(x => x.Orders);
        }
    }
}
