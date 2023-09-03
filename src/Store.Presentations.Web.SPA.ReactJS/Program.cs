using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace Store.Presentations.Web.SPA.ReactJS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var customEnviroment = "Development";
            #if TEST
                customEnviroment = "Test";
            #elif RELEASE
                customEnviroment = "Production";
            #endif

            Console.WriteLine($"Enviroment is {customEnviroment}");

            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
