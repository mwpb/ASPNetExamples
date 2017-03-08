using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Lesson2
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            if (env.IsProduction())
            {
                // put production specific code
            }

            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(
                    $"This is in {env.EnvironmentName}\n"+
                    $"with config: {Configuration["Message"]}\n"+
                    $"Stuff from the library: {testLib.Class1.Greeting()}"
                    );
            });

        }
    }
}
