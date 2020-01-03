using System;
using System.Collections.Generic;

namespace Store.Core.Domain.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }

        public DateTime RegistrationDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public DateTime? CancellationDate { get; set; }

        public Customer Customer { get; set; }
        public ICollection<OrderedProduct> OrderedProducts { get; set; }
        public Order()
        {
            OrderedProducts = new HashSet<OrderedProduct>();
        }
    }
}
