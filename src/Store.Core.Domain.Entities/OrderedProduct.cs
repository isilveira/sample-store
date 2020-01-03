﻿using System;

namespace Store.Core.Domain.Entities
{
    public class OrderedProduct
    {
        public int OrderedProductID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }

        public int Amount { get; set; }
        public decimal Value { get; set; }

        public DateTime RegistrationDate { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
        public OrderedProduct()
        {

        }
    }
}
