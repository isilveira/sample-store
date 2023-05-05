using BAYSOFT.Abstractions.Infrastructures.Data;
using Store.Core.Domain.Contexts.Default.Interfaces.Infrastructures.Data;

namespace Store.Infrastructures.Data.Contexts.Default
{
    public class DefaultDbContextReader : Reader, IDefaultDbContextReader
    {
        public DefaultDbContextReader(DefaultDbContext context) : base(context)
        {
        }
    }
}
