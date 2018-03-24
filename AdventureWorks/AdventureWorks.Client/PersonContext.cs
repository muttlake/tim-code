

using System.IO;
using AdventureWorks.Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace AdventureWorks.Client
{
    public class PersonContext : DbContext
    {
        public IConfiguration Configuration {get; set; }
        
        public PersonContext()
        {
            Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.dev.json").Build();
        }
        public DbSet<Person> Persons { get; set; } // like a table of persons
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //This works
            System.Console.WriteLine("Person Context connection string: " + Configuration.GetConnectionString("DefaultConnection"));
            builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

        }
    }
}