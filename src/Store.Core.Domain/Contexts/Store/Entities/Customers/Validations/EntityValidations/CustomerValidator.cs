using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using FluentValidation;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Entity;

namespace Store.Core.Domain.Validations.EntityValidations.Default
{
    public class CustomerValidator : EntityValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{0} cannot be null!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("{0} cannot be empty!");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("{3} must have at least {0} characters!");
            RuleFor(x => x.Name).MaximumLength(128).WithMessage("{3} must have a maximum of {1} characters!");

            RuleFor(x => x.Email).NotNull().WithMessage("{0} cannot be null!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("{0} cannot be empty!");
            RuleFor(x => x.Email).MinimumLength(3).WithMessage("{3} must have at least {0} characters!");
            RuleFor(x => x.Email).MaximumLength(128).WithMessage("{3} must have a maximum of {1} characters!");
        }
    }
}
