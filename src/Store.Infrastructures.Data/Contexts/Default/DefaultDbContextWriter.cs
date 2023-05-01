using BAYSOFT.Abstractions.Infrastructures.Data;
using Store.Core.Domain.Contexts.Default.Interfaces.Infrastructures.Data;

namespace Store.Infrastructures.Data.Contexts.Default
{
    public class DefaultDbContextWriter : Writer, IDefaultDbContextWriter
    {
        public DefaultDbContextWriter(DefaultDbContext context) : base(context)
        {
        }
    }
}
