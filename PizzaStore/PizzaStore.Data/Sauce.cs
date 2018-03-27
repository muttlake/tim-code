using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Sauce
    {
        public Sauce()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int SauceId { get; set; }
        public string Sauce1 { get; set; }
        public double SauceCost { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public ICollection<Pizza> Pizza { get; set; }
    }
}
