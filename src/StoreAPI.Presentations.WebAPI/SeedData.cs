using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreAPI.Core.Application.Interfaces.Infrastructures.Data;
using StoreAPI.Core.Infrastructures.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using StoreAPI.Core.Infrastructures.Data;

namespace StoreAPI.Presentations.WebAPI
{
    public class SeedData
    {
        public static void EnsureSeedData(IConfiguration configuration)
        {
            var services = new ServiceCollection();
            
            services.AddDbContext<IStoreContext, StoreContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            
            var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<IStoreContext>();
                
                ((StoreContext)context).Database.Migrate();

                EnsureSeedData(context, configuration);
            }
        }



        private static void EnsureSeedData(IStoreContext context, IConfiguration configuration)
        {
            context.SeedContext(configuration).Wait();
        }
    }
}
