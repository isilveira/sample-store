using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.Orders.Services.CreateOrder
{
    public class CreateOrderServiceRequest : DomainServiceRequest<Order>
    {
        public CreateOrderServiceRequest(Order payload) : base(payload)
        {
        }
    }
}
