using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.BLogic.Library;

namespace WebApplication.BLogic.Library
{
    public class InventoryItem
    {
        //public Product Product { get; set; }
        //public int Quantity { get; set; }
        //public Location Location { get; set; }
        private int inventoryId;
        public int InventoryId
        {
            get => inventoryId;
            set
            {
                //if (value <= 0)
                //    throw new ArgumentException("Invalid Inventory ID", nameof(value));
                inventoryId = value;
            }
        }

        public int ProductId;

        public int StoreId;

        private int quantity;

        public int Quantity
        {
            get => quantity;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Inventory cannot be negative", nameof(value));
                quantity = value;
            }
        }


    }
}
