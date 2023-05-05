using BAYSOFT.Abstractions.Core.Application;
using Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Entity;

namespace Store.Core.Application.Contexts.Store.OrderedProducts.Commands.DeleteOrderedProduct
{
    public class DeleteOrderedProductCommand : ApplicationRequest<OrderedProduct, DeleteOrderedProductCommandResponse>
    {
        public DeleteOrderedProductCommand()
        {
            ConfigKeys(x => x.Id);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Product);
            ConfigSuppressedProperties(x => x.Order);

            ConfigSuppressedResponseProperties(x => x.Product);
            ConfigSuppressedResponseProperties(x => x.Order);
        }
    }
}
