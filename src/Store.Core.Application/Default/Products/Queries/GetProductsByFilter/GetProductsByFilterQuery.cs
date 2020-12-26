using Store.Core.Domain.Entities.Default;

namespace Store.Core.Application.Default.Products.Queries.GetProductsByFilter
{
    public class GetProductsByFilterQuery : ApplicationRequest<Product, GetProductsByFilterQueryResponse>
    {
        public GetProductsByFilterQuery()
        {
            ConfigKeys(x => x.Id);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
