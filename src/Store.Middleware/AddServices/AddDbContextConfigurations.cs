using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Core.Domain.Contexts.Default.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Contexts.Store.Interfaces.Infrastructures.Data;
using Store.Infrastructures.Data.Contexts.Default;
using Store.Infrastructures.Data.Contexts.Store;
using System;
using System.Reflection;

namespace Store.Middleware.AddServices
{
    public static class AddDbContextConfigurations
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DefaultDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sql => {
                        sql.MigrationsAssembly(typeof(DefaultDbContext).Assembly.GetName().Name);
                        sql.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                    }));

            services.AddTransient<IDefaultDbContextWriter, DefaultDbContextWriter>();
            services.AddTransient<IDefaultDbContextReader, DefaultDbContextReader>();

            services.AddDbContext<StoreDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("StoreConnection"),
                    sql => {
                        sql.MigrationsAssembly(typeof(DefaultDbContext).Assembly.GetName().Name);
                        sql.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                    }));

            services.AddTransient<IStoreDbContextWriter, StoreDbContextWriter>();
            services.AddTransient<IStoreDbContextReader, StoreDbContextReader>();

            return services;
        }
        public static IServiceCollection AddDbContextsTest(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DefaultDbContext>(options =>
                options.UseInMemoryDatabase(nameof(DefaultDbContext), new InMemoryDatabaseRoot()),
                ServiceLifetime.Singleton);

            services.AddTransient<IDefaultDbContextWriter, DefaultDbContextWriter>();
            services.AddTransient<IDefaultDbContextReader, DefaultDbContextReader>();

            services.AddDbContext<StoreDbContext>(options =>
                options.UseInMemoryDatabase(nameof(StoreDbContext), new InMemoryDatabaseRoot()),
                ServiceLifetime.Singleton);

            services.AddTransient<IStoreDbContextWriter, StoreDbContextWriter>();
            services.AddTransient<IStoreDbContextReader, StoreDbContextReader>();

            return services;
        }
    }
}
