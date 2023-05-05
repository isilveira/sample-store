using MediatR;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Entity;
using System;

namespace Store.Core.Application.Contexts.Store.Customers.Notifications.PutCustomer
{
    public class PutCustomerNotification : INotification
    {
        public Customer Payload { get; set; }
        public DateTime CreatedAt { get; set; }
        public PutCustomerNotification(Customer payload)
        {
            Payload = payload;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
