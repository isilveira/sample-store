using BAYSOFT.Abstractions.Core.Application;
using Store.Core.Domain.Contexts.Store.Entities.Products.Entity;

namespace Store.Core.Application.Contexts.Store.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : ApplicationRequest<Product, DeleteProductCommandResponse>
    {
        public DeleteProductCommand()
        {
            ConfigKeys(x => x.Id);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Images);
            ConfigSuppressedProperties(x => x.OrderedProducts);

            ConfigSuppressedResponseProperties(x => x.Images);
            ConfigSuppressedResponseProperties(x => x.OrderedProducts);
        }
    }
}
