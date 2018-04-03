using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Pizza2
    {
        public int PizzaId { get; set; }
        public int CrustId { get; set; }
        public int? SauceId { get; set; }
        public int? Cheese1 { get; set; }
        public int? Cheese2 { get; set; }
        public int? Topping1 { get; set; }
        public int? Topping2 { get; set; }
        public int? Topping3 { get; set; }
        public int Quantity { get; set; }
        public double? TotalPizzaCost { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public Cheese Cheese1Navigation { get; set; }
        public Cheese Cheese2Navigation { get; set; }
        public Crust Crust { get; set; }
        public Sauce Sauce { get; set; }
        public Topping Topping1Navigation { get; set; }
        public Topping Topping2Navigation { get; set; }
        public Topping Topping3Navigation { get; set; }
    }
}
