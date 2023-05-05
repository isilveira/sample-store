using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Services.DeleteOrderedProduct
{
    public class DeleteOrderedProductServiceRequest : DomainServiceRequest<OrderedProduct>
    {
        public DeleteOrderedProductServiceRequest(OrderedProduct payload) : base(payload)
        {
        }
    }
}
