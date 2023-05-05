using BAYSOFT.Abstractions.Core.Application;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Entity;

namespace Store.Core.Application.Contexts.Store.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : ApplicationRequest<Order, DeleteOrderCommandResponse>
    {
        public DeleteOrderCommand()
        {
            ConfigKeys(x => x.Id);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Customer);
            ConfigSuppressedProperties(x => x.OrderedProducts);

            ConfigSuppressedResponseProperties(x => x.Customer);
            ConfigSuppressedResponseProperties(x => x.OrderedProducts);
        }
    }
}
