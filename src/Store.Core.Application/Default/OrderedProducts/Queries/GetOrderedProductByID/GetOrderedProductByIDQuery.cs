using Store.Core.Domain.Entities.Default;

namespace Store.Core.Application.Default.OrderedProducts.Queries.GetOrderedProductByID
{
    public class GetOrderedProductByIDQuery : ApplicationRequest<OrderedProduct, GetOrderedProductByIDQueryResponse>
    {
        public GetOrderedProductByIDQuery()
        {
            ConfigKeys(x => x.Id);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
