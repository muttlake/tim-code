

using AdventureWorks.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Data
{
    public class PersonContext : DbContext
    {
        private string dbconnect = "server=adventureworksdb.cxkf3wzoieaw.us-east-2.rds.amazonaws.com; database=adventureworksdb;user id=sqladmin; password=password123";

        public DbSet<Person> Persons { get; set; } // like a table of persons
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(dbconnect);
        }
    }
}