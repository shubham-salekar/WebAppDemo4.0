using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDemo4._0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Strat main");

            CreateHostBuilder(args).Build().Run();
            Console.WriteLine("End main");

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
                {
                    Console.WriteLine("above startup");
                    webBuilder.UseStartup<Startup>();
                    Console.WriteLine("after startup");

                });
    } 
}
