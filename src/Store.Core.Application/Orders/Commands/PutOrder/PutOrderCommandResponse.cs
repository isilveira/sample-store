using ModelWrapper;
using Store.Core.Application.Bases;
using Store.Core.Domain.Entities;
using System.Collections.Generic;

namespace Store.Core.Application.Orders.Commands.PutOrder
{
    public class PutOrderCommandResponse : ResponseBase<Order>
    {
        public PutOrderCommandResponse(WrapRequest<Order> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
