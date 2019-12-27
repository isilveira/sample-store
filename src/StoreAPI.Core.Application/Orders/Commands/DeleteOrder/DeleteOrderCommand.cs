using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;

namespace StoreAPI.Core.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : RequestBase<Order, DeleteOrderCommandResponse>
    {
        public DeleteOrderCommand()
        {
            ConfigKeys(x => x.OrderID);

            ConfigSuppressedProperties(x => x.Customer);
            ConfigSuppressedProperties(x => x.OrderedProducts);
        }
    }
}
