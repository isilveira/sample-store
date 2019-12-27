using ModelWrapper;
using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;

namespace StoreAPI.Core.Application.Customers.Queries.GetCustomersByFilter
{
    public class GetCustomersByFilterQueryResponse : ResponseBase<Customer>
    {
        public GetCustomersByFilterQueryResponse(WrapRequest<Customer> request, object data, string message = null, long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
