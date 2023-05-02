using BAYSOFT.Abstractions.Core.Domain.Entities.Specifications;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Entity;
using Store.Core.Domain.Contexts.Store.Interfaces.Infrastructures.Data;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Store.Core.Domain.Contexts.Store.Entities.Categories.Specifications
{
    public class CategoryNameMustBeUniqueOnRootCategorySpecification : DomainSpecification<Category>
    {
        private IStoreDbContextReader Reader { get; set; }
        public CategoryNameMustBeUniqueOnRootCategorySpecification(
            IStoreDbContextReader reader
        )
        {
            Reader = reader;
            SpecificationMessage = "A register with this name on the root category already exists!";
        }

        public override Expression<Func<Category, bool>> ToExpression()
        {
            return category => Reader.Query<Category>().Any(x =>
                x.Name.ToLower().Equals(category.Name.ToLower())
                && x.Id != category.Id
                && x.RootCategoryId == category.RootCategoryId
            );
        }
    }
}
