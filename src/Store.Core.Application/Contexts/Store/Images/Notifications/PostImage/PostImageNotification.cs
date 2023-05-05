using MediatR;
using Store.Core.Domain.Contexts.Store.Entities.Images.Entity;
using System;

namespace Store.Core.Application.Contexts.Store.Images.Notifications.PostImage
{
    public class PostImageNotification : INotification
    {
        public Image Payload { get; set; }
        public DateTime CreatedAt { get; set; }
        public PostImageNotification(Image payload)
        {
            Payload = payload;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
