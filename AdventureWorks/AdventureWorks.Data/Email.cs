using System;
using System.Collections.Generic;

namespace AdventureWorks.Data
{
    public partial class Email
    {
        public int EmailId { get; set; }
        public int? PersonId { get; set; }
        public string Address { get; set; }
        public DateTime ModifedDate { get; set; }
        public bool? Active { get; set; }

        public Person1 Person { get; set; }
    }
}
