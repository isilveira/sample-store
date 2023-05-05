using MediatR;
using Store.Core.Domain.Contexts.Store.Entities.Images.Entity;
using System;

namespace Store.Core.Application.Contexts.Store.Images.Notifications.PatchImage
{
    public class PatchImageNotification : INotification
    {
        public Image Payload { get; set; }
        public DateTime CreatedAt { get; set; }
        public PatchImageNotification(Image payload)
        {
            Payload = payload;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
