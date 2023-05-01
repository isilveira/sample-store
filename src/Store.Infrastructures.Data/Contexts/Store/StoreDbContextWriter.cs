using BAYSOFT.Abstractions.Infrastructures.Data;
using Store.Core.Domain.Contexts.Store.Interfaces.Infrastructures.Data;

namespace Store.Infrastructures.Data.Contexts.Store
{
    public class StoreDbContextWriter : Writer, IStoreDbContextWriter
    {
        public StoreDbContextWriter(StoreDbContext context) : base(context)
        {
        }
    }
}
