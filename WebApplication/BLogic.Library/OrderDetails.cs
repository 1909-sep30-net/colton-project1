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
                orderDetailId = value;
            }
        }

        public int ProductId {get; set;} 

        public int OrderId;

        private int productQuantity;
 
        public int ProductQuantity
        {
            get => productQuantity;
            set
            {
                    productQuantity = value;
            }
        }



    }
}
