using Microsoft.EntityFrameworkCore;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Entity;
using Store.Infrastructures.Data.Contexts.Default.EntityMappings;

namespace Store.Infrastructures.Data.Contexts.Default
{
    public class DefaultDbContext : DbContext
    {
        public DbSet<Sample> Samples { get; set; }

        protected DefaultDbContext()
        {
            Database.Migrate();
        }

        public DefaultDbContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SampleMap());
        }
    }
}
