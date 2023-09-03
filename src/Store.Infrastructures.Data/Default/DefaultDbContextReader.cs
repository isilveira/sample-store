using BAYSOFT.Abstractions.Infrastructures.Data;
using Store.Core.Domain.Default.Interfaces.Infrastructures.Data;

namespace Store.Infrastructures.Data.Default
{
    public class DefaultDbContextReader: Reader, IDefaultDbContextReader
    {
        public DefaultDbContextReader(DefaultDbContext context) : base(context)
        {
        }
    }
}
