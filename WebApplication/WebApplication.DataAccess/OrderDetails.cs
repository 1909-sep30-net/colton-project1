﻿using System;
using System.Collections.Generic;

namespace WebApplication.DataAccess
{
    public partial class OrderDetails
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Product Product { get; set; }
    }
}

