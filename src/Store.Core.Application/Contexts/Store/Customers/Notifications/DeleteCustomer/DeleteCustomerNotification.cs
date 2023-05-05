using MediatR;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Entity;
using System;

namespace Store.Core.Application.Contexts.Store.Customers.Notifications.DeleteCustomer
{
    public class DeleteCustomerNotification : INotification
    {
        public Customer Payload { get; set; }
        public DateTime CreatedAt { get; set; }
        public DeleteCustomerNotification(Customer payload)
        {
            Payload = payload;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
