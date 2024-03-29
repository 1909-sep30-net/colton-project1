﻿using System;
using System.Collections.Generic;

namespace WebApplication.Data.Entitis
{
    public partial class Products
    {
        public Products()
        {
            Inventory = new HashSet<Inventory>();
            OrderDetail = new HashSet<OrderDetail>();
        }

        public string Name { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
