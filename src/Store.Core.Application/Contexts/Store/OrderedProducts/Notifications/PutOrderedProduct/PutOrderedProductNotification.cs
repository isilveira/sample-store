using MediatR;
using Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Entity;
using System;

namespace Store.Core.Application.Contexts.Store.OrderedProducts.Notifications.PutOrderedProduct
{
    public class PutOrderedProductNotification : INotification
    {
        public OrderedProduct Payload { get; set; }
        public DateTime CreatedAt { get; set; }
        public PutOrderedProductNotification(OrderedProduct payload)
        {
            Payload = payload;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
