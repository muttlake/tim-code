using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using PizzaStore.Library;
using PizzaStore.Data;

namespace PizzaStore.MVC.Models
{
    public class OrderViewModel
    {

        public int LocationID { get; set; }
        public Dictionary<int, string> ValidLocations { get; set; }

        public OrderViewModel()
        {
            ValidLocations = GetLocations();
        }

        private Dictionary<int, string> GetLocations()
        {
            EfData ef = new EfData();
            Dictionary<int, string> locationDict = new Dictionary<int, string>();
            foreach (var location in ef.ReadLocations())
            {
                string locString = "";
                locString += location.Address.Street;
                locString += ", " + location.Address.City;
                locString += ", " + location.Address.State.StateAbb;
                locString += ", " + location.Address.City;
                locationDict[location.LocationId] = locString;
            }
            return locationDict;
        }
    }
}
