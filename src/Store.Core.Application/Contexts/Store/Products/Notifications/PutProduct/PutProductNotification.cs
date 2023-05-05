using MediatR;
using Store.Core.Domain.Contexts.Store.Entities.Products.Entity;
using System;

namespace Store.Core.Application.Contexts.Store.Products.Notifications.PutProduct
{
    public class PutProductNotification : INotification
    {
        public Product Payload { get; set; }
        public DateTime CreatedAt { get; set; }
        public PutProductNotification(Product payload)
        {
            Payload = payload;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
