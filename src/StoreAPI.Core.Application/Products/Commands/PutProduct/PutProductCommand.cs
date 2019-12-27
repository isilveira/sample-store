using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;

namespace StoreAPI.Core.Application.Products.Commands.PutProduct
{
    public class PutProductCommand : RequestBase<Product, PutProductCommandResponse>
    {
        public PutProductCommand()
        {
            ConfigKeys(x => x.ProductID);

            ConfigSuppressedProperties(x => x.OrderedProducts);
            ConfigSuppressedProperties(x => x.Images);
            ConfigSuppressedProperties(x => x.Category);

            ConfigSuppressedResponseProperties(x => x.Category);
            ConfigSuppressedResponseProperties(x => x.Images);
            ConfigSuppressedResponseProperties(x => x.OrderedProducts);
        }
    }
}
