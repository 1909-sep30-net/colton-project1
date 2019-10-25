using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.BLogic.Library
{
    public class OrderDetails
    {
        private int orderDetailId;
        public int OrderDetailId
        {
            get => orderDetailId;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Invalid Order Detail ID", nameof(value));
                orderDetailId = value;
            }
        }

        public int ProductId;

        public int OrderId;

        private int productQuantity;

        public int ProductQuantity
        {
            get => productQuantity;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Stock cannot be neg", nameof(value));
                ProductQuantity = value;
            }
        }



    }
}
