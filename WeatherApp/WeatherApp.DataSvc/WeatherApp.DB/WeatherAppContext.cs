using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WeatherApp.DataSvc.WeatherApp.DB
{
	public class WeatherAppContext : DbContext, IDisposable
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Post> Posts { get; set; }

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
		}

	}
}
