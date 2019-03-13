using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using StoreAPI.Core.Application.Interfaces;
using StoreAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Core.Infrastructures.Data
{
    public class StoreContext : DbContext, IStoreContext
    {
        protected StoreContext()
        {
            base.Database.EnsureCreated();
        }

        public StoreContext(DbContextOptions options) : base(options)
        {
            base.Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }
    }
}
