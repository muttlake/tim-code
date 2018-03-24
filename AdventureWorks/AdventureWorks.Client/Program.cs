using System;
using AdventureWorks.Data;
using AdventureWorks.Library.Models;
using System.Collections.Generic;


namespace AdventureWorks.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var ed = new EfData();

            if (ed.Insert())
            {
                System.Console.WriteLine("it works");
            }
            else
            {
                System.Console.WriteLine("noooo");
            }


            foreach (var item in ed.ReadAW())
            {
                System.Console.WriteLine("{0} {1}", item.FirstName, item.LastName);
            }
            // foreach (var item in ed.ReadAW())
            // {
            //     System.Console.WriteLine("{0} {1}". item.FirstName, item.LastName);
            // }

            // var adodata = new AdoData();
            // // var s = adodata.ReadConnected();
            // // Console.WriteLine(s);

            // // s = adodata.ReadDisconnected();
            // // Console.WriteLine("\n");
            // // Console.WriteLine(s);

            // var people = new List<Person>();
            // people = adodata.ReadPeopleDisconnected();
            // Console.WriteLine("Number of people: {0}", people.Count);

            // foreach(var person in people)
            // {
            //     Console.WriteLine(person);
            // }

            // if(adodata.Insert())
            //     Console.WriteLine("Inserted");
            // else
            //     Console.WriteLine("Failed to insert");

            // var pc = new PersonContext();            


        }
    }
}
