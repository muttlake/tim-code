

using System.Collections.Generic;
using System.Linq;
using AdventureWorks.Library.Models;

namespace AdventureWorks.Data
{
    public class EfData
    {
        //We need Entity FW pieces

        // Something else is managing connection
        private PersonContext db = new PersonContext();

        public List<Person> Read()
        {
            return db.Persons.ToList();
        }
    }
}