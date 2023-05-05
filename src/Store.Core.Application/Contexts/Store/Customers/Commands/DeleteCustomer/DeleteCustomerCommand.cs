using BAYSOFT.Abstractions.Core.Application;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Entity;

namespace Store.Core.Application.Contexts.Store.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : ApplicationRequest<Customer, DeleteCustomerCommandResponse>
    {
        public DeleteCustomerCommand()
        {
            ConfigKeys(x => x.Id);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Orders);

            ConfigSuppressedResponseProperties(x => x.Orders);
        }
    }
}
