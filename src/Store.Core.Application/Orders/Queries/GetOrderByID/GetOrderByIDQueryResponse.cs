﻿using ModelWrapper;
using Store.Core.Application.Bases;
using Store.Core.Domain.Entities;

namespace Store.Core.Application.Orders.Queries.GetOrderByID
{
    public class GetOrderByIDQueryResponse : ResponseBase<Order>
    {
        public GetOrderByIDQueryResponse(WrapRequest<Order> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
