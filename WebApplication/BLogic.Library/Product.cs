using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.BLogic.Library
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int Id { get; set; }
        public int InventoryId { get; set; }

        /* public Product(string name, double price, int code)
        {
            this.Name = name;
            this.Price = price;
            this.Code = code;
        }*/

    }
}
