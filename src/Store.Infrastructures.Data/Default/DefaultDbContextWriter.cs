using BAYSOFT.Abstractions.Infrastructures.Data;
using Store.Core.Domain.Default.Interfaces.Infrastructures.Data;

namespace Store.Infrastructures.Data.Default
{
    public class DefaultDbContextWriter : Writer, IDefaultDbContextWriter
    {
        public DefaultDbContextWriter(DefaultDbContext context) : base(context)
        {
        }
    }
}
