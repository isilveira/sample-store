using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Core.Domain.Entities.Default
{
    public class Order : DomainEntity
    {
        public int Id { get; set; }
        
        public Order()
        {
        }
    }
}
