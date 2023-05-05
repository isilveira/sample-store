using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.Orders.Services.DeleteOrder
{
    public class DeleteOrderServiceRequest : DomainServiceRequest<Order>
    {
        public DeleteOrderServiceRequest(Order payload) : base(payload)
        {
        }
    }
}
