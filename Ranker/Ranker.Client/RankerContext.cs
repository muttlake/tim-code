using System;
using System.Collections.Generic;
using System.IO;
using Ranker.Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ranker.Client
{
    public class RankerContext : DbContext, IDisposable
    {
	    public DbSet<User> Users { get; set; }
	    public DbSet<Typer> Typers { get; set; }
	    public DbSet<Thing> Things { get; set; }
	    public DbSet<Ranking> Rankings { get; set; }
	    public DbSet<RankedItem> RankedItems { get; set; }

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
			Typers = null;
			Things = null;
			Rankings = null;
			RankedItems = null;
		}

    }
}
