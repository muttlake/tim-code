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
                Console.Write("Enter a name for a new FoodType: "); 
                var name = Console.ReadLine(); 
    
                var ft = new FoodType(name);
                db.FoodTypes.Add(ft); 
                db.SaveChanges(); 
    
                // Display all Blogs from the database 
                var query = from b in db.FoodTypes 
                            select b; 
    
                Console.WriteLine("All blogs in the database:"); 
                foreach (var item in query) 
                { 
                    Console.WriteLine(item.Name); 
                } 
    
                Console.WriteLine("Press any key to exit..."); 
                Console.ReadKey(); 
            } 
	    
        }
    }
}
