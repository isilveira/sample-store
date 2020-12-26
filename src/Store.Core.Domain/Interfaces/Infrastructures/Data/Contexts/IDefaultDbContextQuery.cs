using Store.Core.Domain.Entities.Default;
using Microsoft.EntityFrameworkCore;

namespace Store.Core.Domain.Interfaces.Infrastructures.Data.Contexts
{
    public interface IDefaultDbContextQuery
    {
        public DbSet<Sample> Samples { get; set; }
    }
}
