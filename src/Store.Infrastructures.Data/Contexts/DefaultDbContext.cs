using Store.Core.Domain.Entities.Default;
using Store.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Store.Infrastructures.Data.Contexts
{
    public class DefaultDbContext : DbContext, IDefaultDbContext
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
    }
}
