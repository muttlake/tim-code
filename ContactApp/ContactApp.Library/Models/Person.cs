
using System.Collections.Generic;
using ContactApp.Library.Enums;

namespace ContactApp.Library.Models  // We are in Models folder
{
    public class Person  // name of file should match name of class
    {
        public Name Name { get; set; }

        public Phone Phone { get; set; }

        public Dictionary<ContactEnum, string> Email { get; set; }
    
        public Dictionary<ContactEnum, Address> Address { get; set; }  //usually C# we either deal with lists or dictionaries
    }
}