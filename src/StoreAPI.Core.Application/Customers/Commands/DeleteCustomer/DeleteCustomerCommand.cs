using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;

namespace StoreAPI.Core.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : RequestBase<Customer, DeleteCustomerCommandResponse>
    {
        public DeleteCustomerCommand()
        {
            ConfigKeys(x => x.CustomerID);

            ConfigSuppressedProperties(x => x.Orders);
        }
    }
}
