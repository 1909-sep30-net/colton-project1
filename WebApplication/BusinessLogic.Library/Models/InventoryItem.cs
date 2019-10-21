﻿using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.BusinessLogic.Library;

namespace WebApplication.BusinessLogic.Library
{
    public class InventoryItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Location Location { get; set; }
    }
}
