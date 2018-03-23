using System;
using System.Collections.Generic;

namespace AdventureWorks.Data
{
    public partial class Name
    {
        public Name()
        {
            Persons = new HashSet<Persons>();
        }

        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }

        public ICollection<Persons> Persons { get; set; }
    }
}
