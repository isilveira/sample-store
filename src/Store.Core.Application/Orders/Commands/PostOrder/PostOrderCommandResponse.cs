using ModelWrapper;
using Store.Core.Application.Bases;
using Store.Core.Domain.Entities;
using System.Collections.Generic;

namespace Store.Core.Application.Orders.Commands.PostOrder
{
    public class PostOrderCommandResponse : ResponseBase<Order>
    {
        public PostOrderCommandResponse(WrapRequest<Order> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
