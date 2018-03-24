using System;
using System.Collections.Generic;

namespace AdventureWorks.Data
{
    public partial class Person1
    {
        public Person1()
        {
            Email = new HashSet<Email>();
        }

        public int PersonId { get; set; }
        public int? PhoneId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ModifedDate { get; set; }
        public bool? Active { get; set; }
        public string FullName { get; set; }

        public Phone Phone { get; set; }
        public ICollection<Email> Email { get; set; }
    }
}
