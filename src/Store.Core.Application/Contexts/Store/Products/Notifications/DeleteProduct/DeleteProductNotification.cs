using MediatR;
using Store.Core.Domain.Contexts.Store.Entities.Products.Entity;
using System;

namespace Store.Core.Application.Contexts.Store.Products.Notifications.DeleteProduct
{
    public class DeleteProductNotification : INotification
    {
        public Product Payload { get; set; }
        public DateTime CreatedAt { get; set; }
        public DeleteProductNotification(Product payload)
        {
            Payload = payload;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
