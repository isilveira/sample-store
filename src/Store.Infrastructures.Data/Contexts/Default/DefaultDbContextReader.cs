using BAYSOFT.Abstractions.Infrastructures.Data;
using Store.Core.Domain.Contexts.Default.Interfaces.Infrastructures.Data;

namespace Store.Infrastructures.Data.Contexts.Default
{
    public class DefaultDbContextReader : Reader, IDeafultDbContextReader
    {
        public DefaultDbContextReader(DefaultDbContext context) : base(context)
        {
        }
    }
}
