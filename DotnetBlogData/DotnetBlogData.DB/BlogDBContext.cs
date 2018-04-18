using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
//using DotnetBlogData.DB;

namespace DotnetBlogData.DB
{
    public class BlogDBContext : DbContext
    {

        private IConfiguration Configuration;
        private string Connection;

        public DbSet<Article> Articles { get; set; }

        public BlogDBContext()
        {
            
        }

        public BlogDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
            Connection = Configuration.GetSection("ConnectionString").Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("server = pizzastoredb.cxkf3wzoieaw.us-east-2.rds.amazonaws.com; initial catalog = pizzastoredb; user id = sqladmin; password = password123;");
        }


    }
}
