using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Crust
    {
        public Crust()
        {
            Pizza = new HashSet<Pizza>();
            Pizza2 = new HashSet<Pizza2>();
        }

        public int CrustId { get; set; }
        public string Crust1 { get; set; }
        public double CrustCost { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public ICollection<Pizza> Pizza { get; set; }
        public ICollection<Pizza2> Pizza2 { get; set; }
    }
}
