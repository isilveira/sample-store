using ModelWrapper;
using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;

namespace StoreAPI.Core.Application.Customers.Commands.PatchCustomer
{
    public class PatchCustomerCommandResponse : ResponseBase<Customer>
    {
        public PatchCustomerCommandResponse(WrapRequest<Customer> request, object data, string message = null, long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
