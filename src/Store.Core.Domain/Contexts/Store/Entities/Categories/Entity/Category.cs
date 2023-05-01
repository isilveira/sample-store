using BAYSOFT.Abstractions.Core.Domain.Entities;
using Store.Core.Domain.Contexts.Store.Entities.Products.Entity;
using System.Collections.Generic;

namespace Store.Core.Domain.Contexts.Store.Entities.Categories.Entity
{
    public class Category : DomainEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? RootCategoryId { get; set; }
        public Category RootCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; }
        public ICollection<Product> Products { get; set; }
        public Category()
        {
            SubCategories = new HashSet<Category>();
            Products = new HashSet<Product>();
        }
    }
}
