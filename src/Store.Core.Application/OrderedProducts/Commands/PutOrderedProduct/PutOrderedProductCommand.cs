using MediatR;
using ModelWrapper;
using Store.Core.Application.Bases;
using Store.Core.Domain.Entities;
using System;

namespace Store.Core.Application.OrderedProducts.Commands.PutOrderedProduct
{
    public class PutOrderedProductCommand : RequestBase<OrderedProduct, PutOrderedProductCommandResponse>
    {
        public PutOrderedProductCommand()
        {
            ConfigKeys(x => x.OrderedProductID);

            ConfigSuppressedProperties(x => x.Product);
            ConfigSuppressedProperties(x => x.Order);
        }
    }
}
