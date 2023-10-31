using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("EmployeeDbConnection")));

            services.AddIdentity<ApplocationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()       // setting [Authorize] Attr Globally.
                                .RequireAuthenticatedUser()
                                .Build();
                config.Filters.Add( new AuthorizeFilter(policy));
            });                      // internally calls AddMvcCore() and also add AddJsonFormatters()
            //services.AddMvcCore();
            services.AddScoped<IEmpRepository, SQLEmpRepository>();  

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error"); 
                app.UseStatusCodePagesWithRedirects("/Error/{0}"); 
            }

            app.UseFileServer();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello Bharat!");
                });

                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Details}/{Id?}");
            });
            Console.WriteLine("configure end");

        }
    }
}
