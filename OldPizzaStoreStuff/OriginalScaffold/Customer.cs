using System;
using System.Collections.Generic;

namespace PizzaStore.Library
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Address Address { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
