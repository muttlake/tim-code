using System;
using FoodRanker.Library;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FoodRanker.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var db = new FoodRankerContext()) 
            { 
                // Create and save a new Blog 
                Console.Write("Enter Stop to Stop: "); 
                var stop = Console.ReadLine(); 
    
                while (!stop.Equals("Stop"))
                {
                //     Console.WriteLine("Enter Firstname: ");
                //     var fn = Console.ReadLine();
                //     Console.WriteLine("Enter Lastname: ");
                //     var ln = Console.ReadLine();
                //     Console.WriteLine("Enter Email: ");
                //     var em = Console.ReadLine();
                //     Console.WriteLine("Enter Username: ");
                //     var un = Console.ReadLine();
                //     Console.WriteLine("Enter Password: ");
                //     var pw = Console.ReadLine();
 
                //     var user = new User(fn, ln, em, un, pw);
                //     db.Users.Add(user); 
                //     db.SaveChanges(); 
                                    
                    Console.Write("Enter Stop to Stop: "); 
                    stop = Console.ReadLine(); 
                }
                                // Display all Blogs from the database 
                var query = from b in db.Users 
                            select b; 
    
                Console.WriteLine("All users in the database:"); 
                foreach (var item in query) 
                { 
                    Console.WriteLine(item.FirstName); 
                } 
    
                Console.WriteLine("Press any key to exit..."); 
                Console.ReadKey(); 
            }
	    
        }
    }
}
