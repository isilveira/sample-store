using MediatR;
using Store.Core.Domain.Contexts.Store.Entities.Products.Entity;
using System;

namespace Store.Core.Application.Contexts.Store.Products.Notifications.PatchProduct
{
    public class PatchProductNotification : INotification
    {
        public Product Payload { get; set; }
        public DateTime CreatedAt { get; set; }
        public PatchProductNotification(Product payload)
        {
            Payload = payload;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
