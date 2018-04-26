using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WeatherApp.DataSvc.WeatherApp.DB;

namespace WeatherApp.DataSvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<WeatherAppContext>(contextLifetime: ServiceLifetime.Scoped, );
            services.AddDbContext<WeatherAppContext>();
            services.AddMvc();

            // Do Cors this way, and then use relevant policy for each controller
            //This only works with one controller right now
            services.AddCors(p => p.AddPolicy("allowAll", c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
            services.AddCors(p => p.AddPolicy("allowHeaders", c => c.AllowAnyHeader()));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
