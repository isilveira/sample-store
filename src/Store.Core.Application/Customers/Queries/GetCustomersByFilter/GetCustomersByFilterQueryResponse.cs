using ModelWrapper;
using Store.Core.Application.Bases;
using Store.Core.Domain.Entities;

namespace Store.Core.Application.Customers.Queries.GetCustomersByFilter
{
    public class GetCustomersByFilterQueryResponse : ResponseBase<Customer>
    {
        public GetCustomersByFilterQueryResponse(WrapRequest<Customer> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
