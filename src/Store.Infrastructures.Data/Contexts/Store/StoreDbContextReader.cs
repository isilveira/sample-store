using BAYSOFT.Abstractions.Infrastructures.Data;
using Store.Core.Domain.Contexts.Store.Interfaces.Infrastructures.Data;

namespace Store.Infrastructures.Data.Contexts.Store
{
    public class StoreDbContextReader : Reader, IStoreDbContextReader
    {
        public StoreDbContextReader(StoreDbContext context) : base(context)
        {
        }
    }
}
