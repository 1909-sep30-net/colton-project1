﻿using System;
using System.Collections.Generic;

namespace WebApplication.DataAccess
{
    public partial class Product
    {
        public Product()
        {
            Inventory = new HashSet<Inventory>();
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
