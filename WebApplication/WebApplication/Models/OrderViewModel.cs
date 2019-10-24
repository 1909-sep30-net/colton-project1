using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class OrderViewModel
    {
        [DisplayName("Customer ID")]
        [Required]
        public int CustomerId { get; set; }

        [DisplayName("Order ID")]
        [Required]
        public int OrderId { get; set; }

        [DisplayName("Order Date")]
        [Required]
        public DateTime OrderDate { get; set; }

        [DisplayName("Order Total")]
        [Required]
        public double Total { get; set; }

        [DisplayName("Store ID")]
        [Required]
        public int StoreId { get; set; }

        public List<LocationViewModel> AllStores;

        public List<ProductViewModel> Inventory;

    }
}
