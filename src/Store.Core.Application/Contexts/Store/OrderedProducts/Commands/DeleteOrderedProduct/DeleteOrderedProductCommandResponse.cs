using BAYSOFT.Abstractions.Core.Application;
using ModelWrapper;
using Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Entity;
using System;
using System.Collections.Generic;

namespace Store.Core.Application.Contexts.Store.OrderedProducts.Commands.DeleteOrderedProduct
{
    public class DeleteOrderedProductCommandResponse : ApplicationResponse<OrderedProduct>
    {
        public DeleteOrderedProductCommandResponse(Tuple<int, int, WrapRequest<OrderedProduct>, Dictionary<string, object>, Dictionary<string, object>, string, long?> tuple) : base(tuple)
        {
        }

        public DeleteOrderedProductCommandResponse(WrapRequest<OrderedProduct> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
