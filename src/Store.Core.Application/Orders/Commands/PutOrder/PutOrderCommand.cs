using MediatR;
using ModelWrapper;
using Store.Core.Application.Bases;
using Store.Core.Domain.Entities;
using System;

namespace Store.Core.Application.Orders.Commands.PutOrder
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
