using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Core.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public List<Image> Images { get; set; }
        public Category Category { get; set; }
        public List<OrderedProduct> OrderedProducts { get; set; }
    }
}
