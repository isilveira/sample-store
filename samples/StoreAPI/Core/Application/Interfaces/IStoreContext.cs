using Microsoft.EntityFrameworkCore;
using StoreAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreAPI.Core.Application.Interfaces
{
    public interface IStoreContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Image> Images { get; set; }

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
