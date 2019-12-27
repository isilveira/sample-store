﻿using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;

namespace StoreAPI.Core.Application.OrderedProducts.Queries.GetOrderedProductsByFilter
{
    public class GetOrderedProductsByFilterQuery : RequestBase<OrderedProduct, GetOrderedProductsByFilterQueryResponse>
    {
        protected GetOrderedProductsByFilterQuery()
        {
            ConfigKeys(x => x.OrderedProductID);

            ConfigSuppressedProperties(x => x.RegistrationDate);
            ConfigSuppressedProperties(x => x.Order);
            ConfigSuppressedProperties(x => x.Product);

            ConfigSuppressedResponseProperties(x => x.Order);
            ConfigSuppressedResponseProperties(x => x.Product);
        }
    }
}
