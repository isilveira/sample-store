using BAYSOFT.Abstractions.Core.Domain.Entities.Specifications;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Entity;
using Store.Core.Domain.Contexts.Store.Interfaces.Infrastructures.Data;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Store.Core.Domain.Contexts.Store.Entities.Customers.Specifications
{
    public class CustomerEmailMustBeUniqueSpecification : DomainSpecification<Customer>
    {
        private IStoreDbContextReader Reader { get; set; }
        public CustomerEmailMustBeUniqueSpecification(
            IStoreDbContextReader reader
        )
        {
            Reader = reader;
            SpecificationMessage = "A register with this email already exists!";
        }

        public override Expression<Func<Customer, bool>> ToExpression()
        {
            return customer => Reader.Query<Customer>().Any(x => 
                x.Email.ToLower().Equals(customer.Email.ToLower())
            );
        }
    }
}
