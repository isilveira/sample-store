using BAYSOFT.Abstractions.Core.Application;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Entity;

namespace Store.Core.Application.Contexts.Store.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery : ApplicationRequest<Order, GetOrderByIdQueryResponse>
    {
        public GetOrderByIdQuery()
        {
            ConfigKeys(x => x.Id);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Customer);
            ConfigSuppressedProperties(x => x.OrderedProducts);

            ConfigSuppressedResponseProperties(x => x.Customer);
            ConfigSuppressedResponseProperties(x => x.OrderedProducts);
        }
    }
}
