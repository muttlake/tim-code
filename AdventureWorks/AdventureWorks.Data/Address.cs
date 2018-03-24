using System;
using System.Collections.Generic;

namespace AdventureWorks.Data
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
