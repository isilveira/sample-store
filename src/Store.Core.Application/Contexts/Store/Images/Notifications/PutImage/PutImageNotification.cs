using MediatR;
using Store.Core.Domain.Contexts.Store.Entities.Images.Entity;
using System;

namespace Store.Core.Application.Contexts.Store.Images.Notifications.PutImage
{
    public class PutImageNotification : INotification
    {
        public Image Payload { get; set; }
        public DateTime CreatedAt { get; set; }
        public PutImageNotification(Image payload)
        {
            Payload = payload;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
