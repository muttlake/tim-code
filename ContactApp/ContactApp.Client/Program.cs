using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using ContactApp.Library;
using ContactApp.Library.Models;

namespace ContactApp.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //PlayWithContact();
            //PlayWithDelegate();
            //PlayWithEvent();

            var arrNames = new string[] { "12345", "fred", "Fred", "fred1", "" };
            //string validName;

            // foreach (var s in arrNames)
            // {
            //     if(NameCheck(s, out string validName))
            //     {
            //         System.Console.WriteLine("your valid name is: {0}", validName);
            //         continue;
            //     }
            //     System.Console.WriteLine("your name should not be: {0}", validName);
            // }

            string first;
            string middle;
            string last;
            foreach (var s in arrNames)
            {
                first = s + "1";
                middle = s + "2";
                last = s + "3";

                //if(NameCheck(last: last, first: first , middle: middle)) // named parameters
                if(NameCheck(last: last, first: ref first , middle: middle)) // named parameters, this is boxing(a string value)
                {
                    System.Console.WriteLine("your valid name is: {0}", first);
                }
                else
                {
                    System.Console.WriteLine("your name should not be: {0}", last);
                }
            }

            //Params give you option of passing a number of things or one int[] array
            Sum(1, 2, 3);
            Sum(new int[] {1, 2, 3, 4, 5});


            PlayWithParallel();
            Console.WriteLine("Finish Main Thread");


        }

        static void PlayWithEvent()
        {
            var b = new Broadcaster();
            var r = new Receiver();
            
            r.Receiving(b); // Need Receive before Broadcast
            b.Broadcast();

            // b.Broadcast(); //get nothing becaue it is sync, all 10 happenned before we were listening.
            // r.Receiving(b);
            // b.Broadcast();
        }

        static bool NameCheck(string name, out string validName) // has default parameter
        {
            if(Regex.IsMatch(name, "^[a-z]*$"))
            {
                validName = name;
                return true;
            }
            //var s = validName; illegal because validName is not expected to have value, it is a bucket to take validName out
            validName = "Not Valid";
            return false;
        }


        static bool NameCheck(ref string first, string middle, string last = "Default last")
        {
            if(Regex.IsMatch(first, "^[a-z].*$"))
            {
                var temp = last;
                last = first;
                first = middle;
                middle = temp;
                return true;
            }
            
            //validName = "Not Valid";
            return false;
        }


        //How can we pass multiple parameters?

        // static double Sum(List<int> i)
        // {
        //     return 1.0;
        // }
        static double Sum(params int[] i)
        {
            return 1.0;
        }

        static void PlayWithDelegate()
        {
            var ch = new ContactHelper<Person>();
            string s = ch.Hello4(() => {return "Goodbye";});  // closure
            System.Console.WriteLine(s);
            System.Console.WriteLine(ch.Hello3());
            //System.Console.WriteLine(ch.hello());
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
            ch.WriteToText();
            ch.WriteToXml();

            Person p3 = ch.ReadPersonFromTxt();
            Console.WriteLine(p3);

            Person p4 = ch.ReadFromXml();
            Console.WriteLine(p4);

            //Person p2 = Person.ReadPersonFromTxt();

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

        static void PlayWithParallel()
        {
            var p = new Parallel();
            //p.WorkWithThread();
            //p.WorkWithTask();
            //p.WorkWithAsync();
            //Thread.Sleep(10); // Sleep Main thread for 10ms
            //p.WorkWithAsync().GetAwaiter(); //Telling main thread to pause when it get here
            p.WorkWithAsync().GetAwaiter().GetResult(); //This is basically synchronous again, you pause until finished

        }
    }
}
