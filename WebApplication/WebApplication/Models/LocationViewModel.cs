using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class LocationViewModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [Required]
        public string City { get; set; }
    }
}
