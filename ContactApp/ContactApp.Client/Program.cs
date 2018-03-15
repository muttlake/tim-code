using System;
using ContactApp.Library;
using ContactApp.Library.Models;

namespace ContactApp.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var contacts = new ContactHelper<Person>();

            var john = new Person();
            john.Name.First = "John";
            john.Name.Last = "Smith";
            john.Phone.Area = "800";
            john.Phone.Number = "555-5555";

            contacts.Add(john);
            contacts.Add(new Person());
        }
    }
}
