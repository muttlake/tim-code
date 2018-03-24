using System;
using System.Collections.Generic;

namespace PizzaStore.Library
{
    public partial class Crust
    {
        public Crust()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int CrustId { get; set; }
        public string Crust1 { get; set; }
        public double CrustCost { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public ICollection<Pizza> Pizza { get; set; }
    }
}
