using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;

namespace StoreAPI.Core.Application.Orders.Queries.GetOrderByID
{
    public class GetOrderByIDQuery : RequestBase<Order, GetOrderByIDQueryResponse>
    {
        public GetOrderByIDQuery()
        {
            ConfigKeys(x => x.OrderID);

            ConfigSuppressedProperties(x => x.RegistrationDate);
            ConfigSuppressedProperties(x => x.OrderedProducts);
            ConfigSuppressedProperties(x => x.Customer);

            ConfigSuppressedResponseProperties(x => x.OrderedProducts);
            ConfigSuppressedResponseProperties(x => x.Customer);
        }
    }
}
