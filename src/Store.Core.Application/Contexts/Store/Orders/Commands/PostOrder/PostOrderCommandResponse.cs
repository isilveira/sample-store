using BAYSOFT.Abstractions.Core.Application;
using ModelWrapper;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Entity;
using System;
using System.Collections.Generic;

namespace Store.Core.Application.Contexts.Store.Orders.Commands.PostOrder
{
    public class PostOrderCommandResponse : ApplicationResponse<Order>
    {
        public PostOrderCommandResponse(Tuple<int, int, WrapRequest<Order>, Dictionary<string, object>, Dictionary<string, object>, string, long?> tuple) : base(tuple)
        {
        }

        public PostOrderCommandResponse(WrapRequest<Order> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
