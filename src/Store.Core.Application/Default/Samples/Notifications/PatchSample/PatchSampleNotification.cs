using Store.Core.Domain.Default.Samples.Entities;
using MediatR;
using System;

namespace Store.Core.Application.Default.Samples.Notifications
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