using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }

        public double Price { get; set; }

        [DisplayName("Product ID")]
        public int ProductId { get; set; }

        [DisplayName("Stock")]
        public int ProductQuant { get; set; }

        [DisplayName("Quantity")]
        [Required]
        public int MaxQuant { get; set; }

        [DisplayName("Inventory ID")]
        public int InventoryId { get; set; }




    }
}
