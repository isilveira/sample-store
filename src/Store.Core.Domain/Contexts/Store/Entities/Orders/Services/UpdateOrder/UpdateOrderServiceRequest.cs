using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.Orders.Services.UpdateOrder
{
    public class UpdateOrderServiceRequest : DomainServiceRequest<Order>
    {
        public UpdateOrderServiceRequest(Order payload) : base(payload)
        {
        }
    }
}
