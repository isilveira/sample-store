using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;

namespace StoreAPI.Core.Application.Products.Queries.GetProductByID
{
    public class GetProductByIDQuery : RequestBase<Product, GetProductByIDQueryResponse>
    {
        public GetProductByIDQuery()
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
