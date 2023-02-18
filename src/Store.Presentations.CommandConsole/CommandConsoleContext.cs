using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Middleware;
using System;
using System.IO;
using System.Reflection;

namespace Store.Presentations.CommandConsole
{
    public class CommandConsoleContext
    {
        private static IConfiguration configuration;
        private static ServiceProvider serviceProvider;
        public static ServiceProvider GetServiceProvider()
        {
            if(serviceProvider == null)
            {
                serviceProvider = new ServiceCollection()
                    .AddMiddleware(GetConfiguration(), typeof(Program).GetTypeInfo().Assembly)
                    .BuildServiceProvider();
            }

            return serviceProvider;
        }

        public static IConfiguration GetConfiguration()
        {
            if (configuration == null)
            {
                var enviroment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIROMENT");

                if (string.IsNullOrWhiteSpace(enviroment))
                    throw new ArgumentNullException("Enviroment not found in ASPNETCORE_ENVIROMENT");

                var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true);

                if (enviroment == "Development")
                {
                    builder.AddJsonFile(
                        Path.Combine(
                            AppContext.BaseDirectory,
                            string.Format("..{0}..{0}..{0}", Path.DirectorySeparatorChar), $"appsettings.{enviroment}.json"
                        ),
                        optional: true
                    );
                }
                else
                {
                    builder
                        .AddJsonFile($"appsettings.{enviroment}.json", optional: false);
                }

                configuration = builder.Build(); 
            }

            return configuration;
        }

        public static IMediator GetMediator()
        {
            return GetServiceProvider().GetService<IMediator>();
        }
    }
}
