using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetBlogData.DB
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext(DbContextOptionsBuilder options, IConfiguration configuration)
        {
            //options.UseSqlServer();
        }
    }
}
