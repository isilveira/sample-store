using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Services.CreateOrderedProduct
{
    public class CreateOrderedProductServiceRequest : DomainServiceRequest<OrderedProduct>
    {
        public CreateOrderedProductServiceRequest(OrderedProduct payload) : base(payload)
        {
        }
    }
}
