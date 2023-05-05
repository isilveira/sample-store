using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using Store.Core.Domain.Contexts.Store.Entities.Products.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.Products.Services.CreateProduct
{
    public class CreateProductServiceRequest : DomainServiceRequest<Product>
    {
        public CreateProductServiceRequest(Product payload) : base(payload)
        {
        }
    }
}
