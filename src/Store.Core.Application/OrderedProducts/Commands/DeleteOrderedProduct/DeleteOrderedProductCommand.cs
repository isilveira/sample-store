using Store.Core.Application.Bases;
using Store.Core.Domain.Entities;

namespace Store.Core.Application.OrderedProducts.Commands.DeleteOrderedProduct
{
    public class DeleteOrderedProductCommand : RequestBase<OrderedProduct, DeleteOrderedProductCommandResponse>
    {
        public DeleteOrderedProductCommand()
        {
            ConfigKeys(x => x.OrderedProductID);

            ConfigSuppressedProperties(x => x.Product);
            ConfigSuppressedProperties(x => x.Order);
        }
    }
}
