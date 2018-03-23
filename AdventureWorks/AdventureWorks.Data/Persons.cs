using System;
using System.Collections.Generic;

namespace AdventureWorks.Data
{
    public partial class Persons
    {
        public int Id { get; set; }
        public int? NameId { get; set; }

        public Name Name { get; set; }
    }
}
