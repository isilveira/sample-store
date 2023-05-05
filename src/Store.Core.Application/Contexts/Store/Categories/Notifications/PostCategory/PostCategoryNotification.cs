using MediatR;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Entity;
using System;

namespace Store.Core.Application.Contexts.Store.Categories.Notifications.PostCategory
{
    public class PostCategoryNotification : INotification
    {
        public Category Payload { get; set; }
        public DateTime CreatedAt { get; set; }
        public PostCategoryNotification(Category payload)
        {
            Payload = payload;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
