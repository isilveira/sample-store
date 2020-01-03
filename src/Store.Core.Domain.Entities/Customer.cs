using System;
using System.Collections.Generic;

namespace Store.Core.Domain.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public DateTime RegistrationDate { get; set; }
        
        public ICollection<Order> Orders { get; set; }
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
    }
}
