using MediatR;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Entity;
using System;

namespace Store.Core.Application.Contexts.Store.Customers.Notifications.PatchCustomer
{
    public class PatchCustomerNotification : INotification
    {
        public Customer Payload { get; set; }
        public DateTime CreatedAt { get; set; }
        public PatchCustomerNotification(Customer payload)
        {
            Payload = payload;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
