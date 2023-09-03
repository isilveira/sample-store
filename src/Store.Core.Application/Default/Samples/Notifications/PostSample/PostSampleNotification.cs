﻿using Store.Core.Domain.Default.Samples.Entities;
using MediatR;
using System;
   
namespace Store.Core.Application.Default.Samples.Notifications
{
    public class PostSampleNotification : INotification
    {
        public Sample Payload { get; set; }
        public DateTime CreatedAt { get; set; }
        public PostSampleNotification(Sample payload)
        {
            Payload = payload;
            CreatedAt = DateTime.UtcNow;
        }
    }
}