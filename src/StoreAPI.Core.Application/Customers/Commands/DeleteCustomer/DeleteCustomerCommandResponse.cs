using ModelWrapper;
using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;

namespace StoreAPI.Core.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandResponse : ResponseBase<Customer>
    {
        public DeleteCustomerCommandResponse(WrapRequest<Customer> request, object data, string message = null, long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
