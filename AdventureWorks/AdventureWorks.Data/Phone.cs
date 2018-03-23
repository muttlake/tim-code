using System;
using System.Collections.Generic;

namespace AdventureWorks.Data
{
    public partial class Phone
    {
        public Phone()
        {
            Person1 = new HashSet<Person1>();
        }

        public int PhoneId { get; set; }
        public string Number { get; set; }
        public DateTime ModifedDate { get; set; }
        public bool? Active { get; set; }

        public ICollection<Person1> Person1 { get; set; }
    }
}
