using ModelWrapper;
using Store.Core.Application.Bases;
using Store.Core.Domain.Entities;

namespace Store.Core.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandResponse : ResponseBase<Customer>
    {
        public DeleteCustomerCommandResponse(WrapRequest<Customer> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
