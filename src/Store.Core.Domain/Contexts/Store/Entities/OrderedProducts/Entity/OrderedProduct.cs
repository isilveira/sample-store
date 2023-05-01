using BAYSOFT.Abstractions.Core.Domain.Entities;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Entity;
using Store.Core.Domain.Contexts.Store.Entities.Products.Entity;
using System;

namespace Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Entity
{
    public class OrderedProduct : DomainEntity<int>
    {
        public int Amount { get; set; }
        public decimal Value { get; set; }
        public DateTime RegisteredAt { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
        public OrderedProduct()
        {
        }
    }
}
