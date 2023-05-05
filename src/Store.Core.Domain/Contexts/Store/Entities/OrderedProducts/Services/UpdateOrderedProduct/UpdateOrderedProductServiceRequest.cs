using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Services.UpdateOrderedProduct
{
    public class UpdateOrderedProductServiceRequest : DomainServiceRequest<OrderedProduct>
    {
        public UpdateOrderedProductServiceRequest(OrderedProduct payload) : base(payload)
        {
        }
    }
}
