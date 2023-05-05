using MediatR;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Entity;
using System;

namespace Store.Core.Application.Contexts.Store.Orders.Notifications.PatchOrder
{
    public class PatchOrderNotification : INotification
    {
        public Order Payload { get; set; }
        public DateTime CreatedAt { get; set; }
        public PatchOrderNotification(Order payload)
        {
            Payload = payload;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
