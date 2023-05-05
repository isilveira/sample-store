using MediatR;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Entity;
using System;

namespace Store.Core.Application.Contexts.Store.Customers.Notifications.PostCustomer
{
    public class PostCustomerNotification : INotification
    {
        public Customer Payload { get; set; }
        public DateTime CreatedAt { get; set; }
        public PostCustomerNotification(Customer payload)
        {
            Payload = payload;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
