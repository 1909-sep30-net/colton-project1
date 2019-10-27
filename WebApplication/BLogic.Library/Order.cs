using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.BLogic.Library
{
    public class Order
    {
        public int Id { get; set; }
        public Location Location { get; set; }
        public Customer Customer { get; set; }

        public decimal Total { get; set; }
        public int LocationId { get; set; }
        public int CustomerId { get; set; }

        public Dictionary<Product, int> cart = new Dictionary<Product, int>();
        public DateTime OrderDateTime { get; set; }

        public List<OrderDetails> ProductSelected = new List<OrderDetails>();

        public List<OrderDetails> OrderDetails { get; set; }

        public Order()
        {
            OrderDateTime = DateTime.Now;
        }

        /* public Order(Location storelocation, Customer customer, string orderDateTime, List<Product> Quantities, List<double> prices)
        {
            this.StoreLocation = storelocation;
            this.Customer = customer;
            this.OrderDateTime = orderDateTime;
            foreach(Product I in Quantities)
            {
                foreach(double price in prices)
                {
                    this.ReceiptValue.Add(I, price);
                }
            }

        } */


        /* public void IncludeProduct(Product product)
        {
            Products.Add(product);
        } */
    }
}



