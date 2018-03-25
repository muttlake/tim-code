using System;
using System.Collections.Generic;

namespace PizzaStore.Library
{
    public partial class Order
    {
        public Order()
        {
            Pizza = new HashSet<Pizza>();
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
    }
}
