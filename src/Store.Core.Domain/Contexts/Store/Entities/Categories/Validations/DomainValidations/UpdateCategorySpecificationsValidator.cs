using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Entity;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Specifications;

namespace Store.Core.Domain.Contexts.Store.Entities.Categories.Validations.DomainValidations
{
    public class UpdateCategorySpecificationsValidator : DomainValidator<Category>
    {
        public UpdateCategorySpecificationsValidator(
            CategoryNameMustBeUniqueOnRootCategorySpecification categoryNameMustBeUniqueOnRootCategorySpecification
        )
        {
            Add("categoryNameMustBeUniqueOnRootCategorySpecification", new DomainRule<Category>(categoryNameMustBeUniqueOnRootCategorySpecification.Not(), categoryNameMustBeUniqueOnRootCategorySpecification.ToString()));
        }
    }
}
