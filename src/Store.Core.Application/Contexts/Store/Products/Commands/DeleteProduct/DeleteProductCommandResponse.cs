using BAYSOFT.Abstractions.Core.Application;
using ModelWrapper;
using Store.Core.Domain.Contexts.Store.Entities.Products.Entity;
using System;
using System.Collections.Generic;

namespace Store.Core.Application.Contexts.Store.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandResponse : ApplicationResponse<Product>
    {
        public DeleteProductCommandResponse(Tuple<int, int, WrapRequest<Product>, Dictionary<string, object>, Dictionary<string, object>, string, long?> tuple) : base(tuple)
        {
        }

        public DeleteProductCommandResponse(WrapRequest<Product> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
