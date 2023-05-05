using MediatR;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Entity;
using System;

namespace Store.Core.Application.Contexts.Store.Orders.Notifications.PostOrder
{
    public class PostOrderNotification : INotification
    {
        public Order Payload { get; set; }
        public DateTime CreatedAt { get; set; }
        public PostOrderNotification(Order payload)
        {
            Payload = payload;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
