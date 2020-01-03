using System;
using System.Collections.Generic;

namespace Store.Core.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Specifications { get; set; }
        public int Amount { get; set; }
        public decimal Value { get; set; }

        public DateTime? RegistrationDate { get; set; }
        public bool IsVisible { get; set; }

        public ICollection<Image> Images { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderedProduct> OrderedProducts { get; set; }

        public Product()
        {
            Images = new HashSet<Image>();
            OrderedProducts = new HashSet<OrderedProduct>();
        }
    }
}
