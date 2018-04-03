using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Order
    {
        public Order()
        {
            Pizza = new HashSet<Pizza>();
            Pizza2 = new HashSet<Pizza2>();
        }

        public int OrderId { get; set; }
        public int LocationId { get; set; }
        public double? TotalValue { get; set; }
        public DateTime OrderTime { get; set; }
        public int CustomerId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public Customer Customer { get; set; }
        public Location Location { get; set; }
        public ICollection<Pizza> Pizza { get; set; }
        public ICollection<Pizza2> Pizza2 { get; set; }
    }
}
