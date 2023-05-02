using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Entity;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Specifications;

namespace Store.Core.Domain.Contexts.Store.Entities.Categories.Validations.DomainValidations
{
    public class CreateCategorySpecificationsValidator : DomainValidator<Category>
    {
        public CreateCategorySpecificationsValidator(
            CategoryNameMustBeUniqueOnRootCategorySpecification categoryNameMustBeUniqueOnRootCategorySpecification
        )
        {
            Add("categoryNameMustBeUniqueOnRootCategorySpecification", new DomainRule<Category>(categoryNameMustBeUniqueOnRootCategorySpecification.Not(), categoryNameMustBeUniqueOnRootCategorySpecification.ToString()));
        }
    }
}
