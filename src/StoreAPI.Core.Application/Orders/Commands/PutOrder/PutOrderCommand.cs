﻿using MediatR;
using ModelWrapper;
using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;
using System;

namespace StoreAPI.Core.Application.Orders.Commands.PutOrder
{
    public class PutOrderCommand : RequestBase<Order, PutOrderCommandResponse>
    {
        public PutOrderCommand()
        {
            ConfigKeys(x => x.OrderID);

            ConfigSuppressedProperties(x => x.Customer);
            ConfigSuppressedProperties(x => x.OrderedProducts);
        }
    }
}
