using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AdWorks.MVC.Models
{
    public class OrderViewModel
    {
        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }


        public int LocationID { get; set; }
        public Dictionary<int, string> ValidLocations { get; set; }

        public OrderViewModel()
        {
            ValidLocations = new Dictionary<int, string>();
            ValidLocations[1] = "17631 Bruce B Downs Blvd, Tampa, FL, 33647";
            ValidLocations[2] = "14917 Bruce B Downs Blvd, Tampa, FL, 33613";
            ValidLocations[3] = "9340 N Florida Ave City, Tampa, FL, 33612";
        }
    }
}
