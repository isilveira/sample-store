using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace StoreAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var seed = args.Contains("/seed");

            if (seed)
            {
                args = args.Except(new[] { "/seed" }).ToArray();
            }

            var host = CreateWebHostBuilder(args).Build();

            if (seed)
            {
                // TODO: Seed database...
            }

            host.Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .CreateWebHostBuilder(webHost =>
                {
                    webHost.UseStartup<Startup>();
                });
    }
}
