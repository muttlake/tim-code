using System;
using System.Collections.Generic;

namespace PizzaStore.Library
{
    public partial class Address
    {
        public Address()
        {
            Customer = new HashSet<Customer>();
            Location = new HashSet<Location>();
        }

        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public ICollection<Customer> Customer { get; set; }
        public ICollection<Location> Location { get; set; }
    }
}
