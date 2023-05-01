using BAYSOFT.Abstractions.Core.Domain.Entities;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Entity;
using System;
using System.Collections.Generic;

namespace Store.Core.Domain.Contexts.Store.Entities.Customers.Entity
{
    public class Customer : DomainEntity<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegisteredAt { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
    }
}
