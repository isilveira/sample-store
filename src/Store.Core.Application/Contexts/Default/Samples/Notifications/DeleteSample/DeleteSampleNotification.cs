using MediatR;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Entity;
using System;

namespace Store.Core.Application.Contexts.Default.Samples.Notifications.DeleteSample
{
    public class DeleteSampleNotification : INotification
    {
        public Sample Payload { get; set; }
        public DateTime CreatedAt { get; set; }
        public DeleteSampleNotification(Sample payload)
        {
            Payload = payload;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
