using BAYSOFT.Abstractions.Core.Application;
using ModelWrapper;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Entity;
using System;
using System.Collections.Generic;

namespace Store.Core.Application.Contexts.Store.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryResponse : ApplicationResponse<Customer>
    {
        public GetCustomerByIdQueryResponse(Tuple<int, int, WrapRequest<Customer>, Dictionary<string, object>, Dictionary<string, object>, string, long?> tuple) : base(tuple)
        {
        }

        public GetCustomerByIdQueryResponse(WrapRequest<Customer> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
