using BAYSOFT.Abstractions.Core.Application;
using ModelWrapper;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Entity;
using System;
using System.Collections.Generic;

namespace Store.Core.Application.Contexts.Store.Customers.Commands.PutCustomer
{
    public class PutCustomerCommandResponse : ApplicationResponse<Customer>
    {
        public PutCustomerCommandResponse(Tuple<int, int, WrapRequest<Customer>, Dictionary<string, object>, Dictionary<string, object>, string, long?> tuple) : base(tuple)
        {
        }

        public PutCustomerCommandResponse(WrapRequest<Customer> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
