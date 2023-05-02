using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using FluentValidation;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.Categories.Validations.EntityValidations
{
    public class CategoryValidator : EntityValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{0} cannot be null!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("{0} cannot be empty!");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("{3} must have at least {0} characters!");
            RuleFor(x => x.Name).MaximumLength(128).WithMessage("{3} must have a maximum of {1} characters!");

            RuleFor(x => x.Description).NotNull().WithMessage("{0} cannot be null!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("{0} cannot be empty!");
            RuleFor(x => x.Description).MinimumLength(3).WithMessage("{3} must have at least {0} characters!");
            RuleFor(x => x.Description).MaximumLength(512).WithMessage("{3} must have a maximum of {1} characters!");
        }
    }
}
