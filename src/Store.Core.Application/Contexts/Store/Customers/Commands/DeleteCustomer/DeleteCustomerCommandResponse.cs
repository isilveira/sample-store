using BAYSOFT.Abstractions.Core.Application;
using ModelWrapper;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Entity;
using System;
using System.Collections.Generic;

namespace Store.Core.Application.Contexts.Store.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandResponse : ApplicationResponse<Customer>
    {
        public DeleteCustomerCommandResponse(Tuple<int, int, WrapRequest<Customer>, Dictionary<string, object>, Dictionary<string, object>, string, long?> tuple) : base(tuple)
        {
        }

        public DeleteCustomerCommandResponse(WrapRequest<Customer> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
