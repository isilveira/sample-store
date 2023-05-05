using MediatR;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Entity;
using System;

namespace Store.Core.Application.Contexts.Default.Samples.Notifications.PutSample
{
    public class PutSampleNotification : INotification
    {
        public Sample Payload { get; set; }
        public DateTime CreatedAt { get; set; }
        public PutSampleNotification(Sample payload)
        {
            Payload = payload;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
