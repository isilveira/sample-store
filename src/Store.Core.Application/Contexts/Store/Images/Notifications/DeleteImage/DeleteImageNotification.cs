using MediatR;
using Store.Core.Domain.Contexts.Store.Entities.Images.Entity;
using System;

namespace Store.Core.Application.Contexts.Store.Images.Notifications.DeleteImage
{
    public class DeleteImageNotification : INotification
    {
        public Image Payload { get; set; }
        public DateTime CreatedAt { get; set; }
        public DeleteImageNotification(Image payload)
        {
            Payload = payload;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
