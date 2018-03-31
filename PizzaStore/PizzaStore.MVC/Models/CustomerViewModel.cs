using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.MVC.Models
{
    public class CustomerViewModel
    {
        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
    }
}
