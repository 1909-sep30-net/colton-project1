using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WebApplication.Models
{
    public class CustomerOrdersViewModel
    {
        public List<OrderViewModel> Orders { get; set; } = new List<OrderViewModel>();

        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }

        [DisplayName("Order ID")]
        public int OrderId { get; set; }

        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        public double Total { get; set; }

        [DisplayName("Store ID")]
        public int StoreId { get; set; }
    }
}
