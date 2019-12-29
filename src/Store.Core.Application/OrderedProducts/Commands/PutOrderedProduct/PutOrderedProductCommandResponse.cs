using ModelWrapper;
using Store.Core.Application.Bases;
using Store.Core.Domain.Entities;
using System.Collections.Generic;

namespace Store.Core.Application.OrderedProducts.Commands.PutOrderedProduct
{
    public class PutOrderedProductCommandResponse : ResponseBase<OrderedProduct>
    {
        public PutOrderedProductCommandResponse(WrapRequest<OrderedProduct> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
