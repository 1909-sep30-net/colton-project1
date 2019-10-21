using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.BLogic.Library;

namespace WebApplication.BLogic.Library
{
    public class InventoryItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Location Location { get; set; }
    }
}
