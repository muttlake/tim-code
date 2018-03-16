
using System;
using System.Collections.Generic;
using ContactApp.Library.Enums;
using ContactApp.Library.Interfaces;
using System.Xml.Serialization;
using System.IO;
using System.Linq;

namespace ContactApp.Library.Models  // We are in Models folder
{
    public class Person: IContact  // name of file should match name of class, // all classes we create inherently come from Object
    {
        public long PId { get; } // Unique Identifier
        public Name Name { get; set; }

        public Phone Phone { get; set; }


        [XmlIgnore]
        public Dictionary<ContactEnum, string> Email { get; set; }
    
        [XmlIgnore]
        public Dictionary<ContactEnum, Address> Address { get; set; }  //usually C# we either deal with lists or dictionaries

        public Person()
        {
            //You would get error if long overflows
            // checked
            // {
            //     PId = DateTime.Now.Ticks; // number of seconds since Jan 1 1970
            // }
            PId = DateTime.Now.Ticks;
            Name = new Name();
            Phone = new Phone();
            Email = new Dictionary<ContactEnum, string>();
            Address = new Dictionary<ContactEnum, Address>();
            Email.Add(ContactEnum.Home, "fred@revature.com");
        }

        public Person(Name name, Phone phone, Dictionary<ContactEnum, string> email, Dictionary<ContactEnum, Address> address)
        {
            PId = DateTime.Now.Ticks;
            Name = name;
            Phone = phone;
            Email = email;
            Address = address;
        }

        public Person(string name)
        {
            PId = DateTime.Now.Ticks;
            Name = new Name(name);
        }

        public static Person EnterPersonInfo()
        {
            string fname, lname;
            Console.WriteLine("First Name: ");
            fname = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            lname = Console.ReadLine();
            var name = new Name(fname, lname);

            string phoneAreaCode, phoneNumber;
            Console.WriteLine("Phone Area Code: ");
            phoneAreaCode = Console.ReadLine();
            Console.WriteLine("Phone Number: ");
            phoneNumber = Console.ReadLine();
            var phone = new Phone(phoneAreaCode, phoneNumber);

            string emailHome, emailWork;
            Console.WriteLine("Home email: ");
            emailHome = Console.ReadLine();
            Console.WriteLine("Work email: ");
            emailWork = Console.ReadLine();
            var email = new Dictionary<ContactEnum, string>();
            email[ContactEnum.Home] = emailHome;
            email[ContactEnum.Work] = emailWork;

            //Address addressHome, addressWork;
            string addressStreet, addressCity, addressState, addressZip;
            Console.WriteLine("Home Address: ");
            Console.WriteLine("Street: ");
            addressStreet = Console.ReadLine();
            Console.WriteLine("City: ");
            addressCity = Console.ReadLine();
            Console.WriteLine("State: ");
            addressState = Console.ReadLine();
            Console.WriteLine("Zip: ");
            addressZip = Console.ReadLine();

            var address = new Dictionary<ContactEnum, Address>();
            address[ContactEnum.Home] = new Address(addressStreet, addressCity, StateEnum.AK, addressZip);
            address[ContactEnum.Work] = new Address(addressStreet, addressCity, StateEnum.AK, addressZip);
            
            return new Person(name, phone, email, address);
        }

        public override string ToString()
        {
            //return base.ToString(); // this is default action fo ToString, Person has no base right now
            //inside Object ToString() returns this.GetType().ToString();
            //return string.Format("{0}\n{1}\n{2}\n{3}", Name, Phone, Email, Address); // Name, Phone, Email, Address are Objects
            string adder = string.Format("Person:  {0}\nPerson:  {1}", Name, Phone);
            foreach (var email in Email)
            {
                adder += string.Format("\nPerson:  {0}", email);
            }

            foreach (var address in Address)
            {
                adder += string.Format("\nPerson:  {0}", address);
            }

            return adder;
        }


    }
}