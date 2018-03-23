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
            var adodata = new AdoData();
            // var s = adodata.ReadConnected();
            // Console.WriteLine(s);

            // s = adodata.ReadDisconnected();
            // Console.WriteLine("\n");
            // Console.WriteLine(s);

            var people = new List<Person>();
            people = adodata.ReadPeopleDisconnected();
            Console.WriteLine("Number of people: {0}", people.Count);

            foreach(var person in people)
            {
                Console.WriteLine(person);
            }


        }
    }
}
