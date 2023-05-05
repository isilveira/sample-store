using MediatR;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Entity;
using System;

namespace Store.Core.Application.Contexts.Store.Orders.Notifications.DeleteOrder
{
    public class DeleteOrderNotification : INotification
    {
        public Order Payload { get; set; }
        public DateTime CreatedAt { get; set; }
        public DeleteOrderNotification(Order payload)
        {
            Payload = payload;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
