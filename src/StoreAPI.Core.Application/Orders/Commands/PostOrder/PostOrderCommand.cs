using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;

namespace StoreAPI.Core.Application.Orders.Commands.PostOrder
{
    public class PostOrderCommand : RequestBase<Order, PostOrderCommandResponse>
    {
        public PostOrderCommand()
        {
            ConfigKeys(x => x.OrderID);

            ConfigSuppressedProperties(x => x.Customer);
            ConfigSuppressedProperties(x => x.OrderedProducts);
        }
    }
}
