using System.Collections.Generic;

namespace Store.Core.Domain.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public int? RootCategoryID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public Category RootCategory { get; set; }
        public ICollection<Category> LeafCategories { get; set; }
        public ICollection<Product> Products { get; set; }
        public Category()
        {
            LeafCategories = new HashSet<Category>();
            Products = new HashSet<Product>();
        }
    }
}
