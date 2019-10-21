using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.BLogic.Library
{
    public class OrderDetails
    {
        public int Id { get; set; }
        //public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; } = new Product();
    }
}
