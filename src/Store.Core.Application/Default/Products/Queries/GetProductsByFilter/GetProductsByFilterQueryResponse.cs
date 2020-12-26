using ModelWrapper;
using Store.Core.Domain.Entities.Default;

namespace Store.Core.Application.Default.Products.Queries.GetProductsByFilter
{
    public class GetProductsByFilterQueryResponse : ApplicationResponse<Product>
    {
        public GetProductsByFilterQueryResponse(WrapRequest<Product> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
