

using System.Collections.Generic;
using System.Linq;
using AdventureWorks.Data;
using AdventureWorks.Library.Models;

namespace AdventureWorks.Client
{
    public class EfData
    {
        //We need Entity FW pieces

        // Something else is managing connection
        private PersonContext db = new PersonContext();
        private AWContext db2 = new AWContext();


        public List<Library.Models.Person> Read()
        {
            return db.Persons.ToList();
        }

        public List<Data.Person> ReadAW()
        {
            return db2.Person.ToList();
        }
        public bool Insert()
        {
            db.Persons.AddRange
            (
                new Library.Models.Person("johnny", "B"),
                new Library.Models.Person("Jimmy", "B"),
                new Library.Models.Person("Horace", "Lim")
                // new Person(),
                // new Person()
            );

            return db.SaveChanges() != 0;
        }
    }
}