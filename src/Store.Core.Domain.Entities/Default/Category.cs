using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Core.Domain.Entities.Default
{
    public class Category : DomainEntity
    {
        public int Id { get; set; }
        
        public Category()
        {
        }
    }
}
