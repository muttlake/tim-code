using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Address
    {
        public Address()
        {
            Customer = new HashSet<Customer>();
        }

        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public string ZipCode { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public State State { get; set; }
        public ICollection<Customer> Customer { get; set; }
    }
}
