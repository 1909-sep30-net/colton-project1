using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class ThankYouViewModel
    {
        //shows What they bought and Total Cost


        [DisplayName("Customer ID")]
        [Required]
        public int CustomerId { get; set; }

        [DisplayName("Store ID")]
        [Required]
        public int StoreId { get; set; }

        public List<LocationViewModel> AllStores;

        [DisplayName("Order ID")]
        public int OrderId { get; set; }

        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [DisplayName("Total")]
        public double Total { get; set; }
    }
}
