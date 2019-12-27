using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;

namespace StoreAPI.Core.Application.Customers.Commands.PutCustomer
{
    public class PutCustomerCommand : RequestBase<Customer, PutCustomerCommandResponse>
    {
        public PutCustomerCommand()
        {
            ConfigKeys(x => x.CustomerID);

            ConfigSuppressedProperties(x => x.Orders);
        }
    }
}
