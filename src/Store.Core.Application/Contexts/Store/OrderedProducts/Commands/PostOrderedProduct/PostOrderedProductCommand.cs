using BAYSOFT.Abstractions.Core.Application;
using Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Entity;

namespace Store.Core.Application.Contexts.Store.OrderedProducts.Commands.PostOrderedProduct
{
    public class PostOrderedProductCommand : ApplicationRequest<OrderedProduct, PostOrderedProductCommandResponse>
    {
        public PostOrderedProductCommand()
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
