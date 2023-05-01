using BAYSOFT.Abstractions.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Entity;
using Store.Core.Domain.Contexts.Store.Entities.Images.Entity;
using Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.Products.Entity
{
    public class Product : DomainEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Specifications { get; set; }
        public int Amount { get; set; }
        public decimal Value { get; set; }
        public DateTime RegisteredAt { get; set; }
        public bool IsVisible { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<OrderedProduct> OrderedProducts { get; set; }
        public Product()
        {
            Images = new HashSet<Image>();
            OrderedProducts = new HashSet<OrderedProduct>();
        }
    }
}
