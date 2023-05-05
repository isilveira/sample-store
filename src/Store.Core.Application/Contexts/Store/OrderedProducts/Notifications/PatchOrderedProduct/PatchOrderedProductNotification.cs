using MediatR;
using Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Entity;
using System;

namespace Store.Core.Application.Contexts.Store.OrderedProducts.Notifications.PatchOrderedProduct
{
    public class PatchOrderedProductNotification : INotification
    {
        public OrderedProduct Payload { get; set; }
        public DateTime CreatedAt { get; set; }
        public PatchOrderedProductNotification(OrderedProduct payload)
        {
            Payload = payload;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
