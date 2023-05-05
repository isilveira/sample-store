using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using Store.Core.Domain.Contexts.Store.Entities.Products.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.Products.Services.DeleteProduct
{
    public class DeleteProductServiceRequest : DomainServiceRequest<Product>
    {
        public DeleteProductServiceRequest(Product payload) : base(payload)
        {
        }
    }
}
