using System;
using ContactApp.Library;
using ContactApp.Library.Models;

namespace ContactApp.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayWithContact();
        }
        static void PlayWithContact()  //PlayWithContact static because Main is static so it must exist when Main runs
        {
            var ch = new ContactHelper<Person>();
            ch.Add(new Person());

            // Console.WriteLine("\nEntering a new person:");
            // Person p = Person.EnterPersonInfo();
            // ch.Add(p);

            Company c = new Company("Revature");
            ch.Add(c);

            Console.WriteLine("\nEnter a new Company name: ");
            string name = Console.ReadLine();
            var cc = new Company(name);
            ch.Add(cc);

            Console.WriteLine("\n\nPrinting out all Persons.");
            foreach (var item in ch.Read())  // Iterates to completion, some people call it the "exhaustive loop"
            {
                System.Console.WriteLine(item);
            }
            Console.WriteLine("\n\n");

            Console.WriteLine("Before Delete: {0}", ch.Size());
            ch.Delete();
            Console.WriteLine("After Delete: {0}", ch.Size());


            // for (int a = 0; a < length; a += 1)   // For each is pretty much same as for
            // {
            //     list[a];
            // }
            // for (;;)  //can 
            // { 
            // }
            // while(true)
            // {
            // }
        }
    }
}
