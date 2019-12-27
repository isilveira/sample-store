using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;

namespace StoreAPI.Core.Application.Customers.Commands.PatchCustomer
{
    public class PatchCustomerCommand : RequestBase<Customer, PatchCustomerCommandResponse>
    {
        public PatchCustomerCommand()
        {
            ConfigKeys(x => x.CustomerID);

            ConfigSuppressedProperties(x => x.Orders);
        }
    }
}
