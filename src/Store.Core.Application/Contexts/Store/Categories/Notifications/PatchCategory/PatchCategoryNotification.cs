using MediatR;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Entity;
using System;

namespace Store.Core.Application.Contexts.Store.Categories.Notifications.PatchCategory
{
    public class PatchCategoryNotification : INotification
    {
        public Category Payload { get; set; }
        public DateTime CreatedAt { get; set; }
        public PatchCategoryNotification(Category payload)
        {
            Payload = payload;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
