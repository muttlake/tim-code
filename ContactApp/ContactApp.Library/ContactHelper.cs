
using System.Collections.Generic;
using ContactApp.Library.Models;

namespace ContactApp.Library
{
    //public class ContactHelper<T> where T : IContact  //Right not Contact list will only have Persons
    public class ContactHelper<T> where T : Person  //Right not Contact list will only have Persons
    {                                               //but could include other things to make contacts of like Companies
        private List<T> container = new List<T>();

        public void Add(T t)
        {
            container.Add(t);
        }
        public void Update(T t)
        {
            container.Add(t);
        }

        public void Delete(T t)
        {
            container.Add(t);
        }
    }
}