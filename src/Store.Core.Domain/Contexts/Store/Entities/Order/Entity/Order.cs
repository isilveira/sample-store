using BAYSOFT.Abstractions.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Store.Core.Domain.Contexts.Store.Entities.Order.Entity
{
    public class Order : DomainEntity<int>
    {
        public DateTime RegisteredAt { get; set; }
        public DateTime? ConfirmedAt { get; set; }
        public DateTime? CancelledAt { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderedProduct> OrderedProducts { get; set; }

        public Order()
        {
            OrderedProducts = new HashSet<OrderedProduct>();
        }
    }
}
