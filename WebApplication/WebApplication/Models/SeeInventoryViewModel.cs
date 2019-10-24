using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class SeeInventoryViewModel
    {
        public List<ProductViewModel> Inventory { get; set; } = new List<ProductViewModel>();

        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }

        [DisplayName("Order ID")]
        public int OrderId { get; set; }

        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        public decimal Total { get; set; }

        [DisplayName("Store ID")]
        public int StoreId { get; set; }
    }
}
