using System;
using System.Collections.Generic;

namespace PizzaStore.Library
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaHasCheese = new HashSet<PizzaHasCheese>();
            PizzaHasTopping = new HashSet<PizzaHasTopping>();
        }

        public int PizzaId { get; set; }
        public int CrustId { get; set; }
        public int SauceId { get; set; }
        public double? TotalPizzaCost { get; set; }
        public int OrderId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public Crust Crust { get; set; }
        public Order Order { get; set; }
        public Sauce Sauce { get; set; }
        public ICollection<PizzaHasCheese> PizzaHasCheese { get; set; }
        public ICollection<PizzaHasTopping> PizzaHasTopping { get; set; }
    }
}
