using Store.Core.Domain.Entities.Default;

namespace Store.Core.Application.Default.OrderedProducts.Commands.DeleteOrderedProduct
{
    public class DeleteOrderedProductCommand : ApplicationRequest<OrderedProduct, DeleteOrderedProductCommandResponse>
    {
        public DeleteOrderedProductCommand()
        {
            ConfigKeys(x => x.Id);

            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);
        }
    }
}
