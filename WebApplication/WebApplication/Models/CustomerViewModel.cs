using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication.Models
{
    public class CustomerViewModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required]

        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]

        public string LastName { get; set; }
    }
}
