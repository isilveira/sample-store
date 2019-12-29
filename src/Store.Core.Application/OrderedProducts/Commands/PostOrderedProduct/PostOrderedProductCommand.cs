﻿using Store.Core.Application.Bases;
using Store.Core.Domain.Entities;

namespace Store.Core.Application.OrderedProducts.Commands.PostOrderedProduct
{
    public class PostOrderedProductCommand : RequestBase<OrderedProduct, PostOrderedProductCommandResponse>
    {
        public PostOrderedProductCommand()
        {
            ConfigKeys(x => x.OrderedProductID);

            ConfigSuppressedProperties(x => x.Product);
            ConfigSuppressedProperties(x => x.Order);
        }
    }
}
