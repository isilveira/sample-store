﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Core.Application.Interfaces.Infrastructures.Data;
using Store.Infrastructures.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using Store.Infrastructures.Data;

namespace Store.Presentations.WebAPI
{
    public class SeedData
    {
        public static void EnsureSeedData(IConfiguration configuration)
        {
            var services = new ServiceCollection();
            
            services.AddDbContext<IStoreContext, StoreDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            
            var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<IStoreContext>();
                
                ((StoreDbContext)context).Database.Migrate();

                EnsureSeedData(context, configuration);
            }
        }



        private static void EnsureSeedData(IStoreContext context, IConfiguration configuration)
        {
            context.SeedContext(configuration).Wait();
        }
    }
}
