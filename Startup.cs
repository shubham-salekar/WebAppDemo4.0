using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDemo4._0.Models;

namespace WebAppDemo4._0
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("Strat ConfigureServices");

            services.AddMvc();                      // internally calls AddMvcCore() and also add AddJsonFormatters()
            //services.AddMvcCore();
            services.AddSingleton<IEmpRepository, MockEmpRepository>();
            Console.WriteLine("End ConfigureServices");

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Console.WriteLine("configure start");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer();
            app.UseRouting();

            //app.UseMvcWithDefaultRoute();

            //app.Run( async (context) =>
            //{
            //    await context.Response.WriteAsync("hello world");
            //});

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello Bharat!");
                //});
                //endpoints.MapControllerRoute(

                //    name: "default",
                //    pattern: "{controller=Home}/{action=Details}/{Id?}"
                // );

                endpoints.MapControllers(); 

            });
            Console.WriteLine("configure end");

        }
    }
}
