using MediatR;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Entity;
using System;

namespace Store.Core.Application.Contexts.Default.Samples.Notifications.PatchSample
{
    public class PatchSampleNotification : INotification
    {
        public Sample Payload { get; set; }
        public DateTime CreatedAt { get; set; }
        public PatchSampleNotification(Sample payload)
        {
            Payload = payload;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
