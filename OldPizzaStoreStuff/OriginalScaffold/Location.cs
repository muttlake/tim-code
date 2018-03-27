using System;
using System.Collections.Generic;

namespace PizzaStore.Library
{
    public partial class Location
    {
        public Location()
        {
            Order = new HashSet<Order>();
        }

        public int LocationId { get; set; }
        public int AddressId { get; set; }
        public int InventoryId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public Address Address { get; set; }
        public Inventory Inventory { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
