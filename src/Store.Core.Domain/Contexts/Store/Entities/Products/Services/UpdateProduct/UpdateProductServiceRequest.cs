using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using Store.Core.Domain.Contexts.Store.Entities.Products.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.Products.Services.UpdateProduct
{
    public class UpdateProductServiceRequest : DomainServiceRequest<Product>
    {
        public UpdateProductServiceRequest(Product payload) : base(payload)
        {
        }
    }
}
