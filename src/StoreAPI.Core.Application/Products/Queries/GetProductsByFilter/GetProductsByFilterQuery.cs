using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;

namespace StoreAPI.Core.Application.Products.Queries.GetProductsByFilter
{
    public class GetProductsByFilterQuery: RequestBase<Product, GetProductsByFilterQueryResponse>
    {
        public GetProductsByFilterQuery()
        {
            SetRestrictProperty(x => x.Category);
            SetRestrictProperty(x => x.Images);
            SetRestrictProperty(x => x.OrderedProducts);
        }
    }
}
