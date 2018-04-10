using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace RestService.Client
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
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

            // Do not do Cors this way
            // app.UseCors(p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()); //You have to pass Cors before you get to Mvc, so cors will work for all controllers
            app.UseMvc();
        }
    }
}
