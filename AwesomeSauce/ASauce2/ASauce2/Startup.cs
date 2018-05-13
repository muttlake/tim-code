using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ASauce2
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            ////These are request delegates, next() gives the next RequestDelegate
            ////layer in the pipeline
            //app.Use(async (context, next) =>
            //{
            //    if (context.Request.Path == "/foo")
            //    {
            //        await context.Response.WriteAsync($"Welcome to Foo");
            //    }
            //    else
            //    {
            //        await next();
            //    }
            //});

            //app.Use(async (context, next) =>
            //{
            //    if (context.Request.Path == "/bar")
            //    {
            //        await context.Response.WriteAsync($"Welcome to Bar");
            //    }
            //    else
            //    {
            //        await next();
            //    }
            //});

            //Map and MapWhen are also extensions for implementing endpoints

            app.Map("/foo",
                config =>
                    config.Use(async (context, next) =>
                        await context.Response.WriteAsync("Welcome to /foo")
                )
            );

            app.MapWhen(context =>
                    context.Request.Method == "POST" &&
                    context.Request.Path == "/bar",
                    config =>
                        config.Use(async (context, next) =>
                            await context.Response.WriteAsync("Welcome to POST /bar")
                    )
            );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //If the request bypasses all previous Use layers, Run will execute
            //the default response
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Welcome to the default");
            });
        }
    }
}
