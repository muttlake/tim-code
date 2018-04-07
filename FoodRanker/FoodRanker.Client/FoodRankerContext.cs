using System;
using System.Collections.Generic;
using System.IO;
using FoodRanker.Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FoodRanker.Client
{
    public class FoodRankerContext : DbContext, IDisposable
    {
	    public DbSet<User> Users { get; set; }
	    public DbSet<FoodType> FoodTypes { get; set; }
	    public DbSet<Ranking> Rankings { get; set; }
	    public DbSet<Food> Foods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.dev.json").Build();
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
        }
		void IDisposable.Dispose()
		{
			Users = null;
			FoodTypes = null;
			Rankings = null;
			Foods = null;
		}

    }
}
