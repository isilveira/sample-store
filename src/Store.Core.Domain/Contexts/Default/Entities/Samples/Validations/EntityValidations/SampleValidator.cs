using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using FluentValidation;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Entity;

namespace Store.Core.Domain.Contexts.Default.Entities.Samples.Validations.EntityValidations.Default
{
    public class SampleValidator : EntityValidator<Sample>
    {
        public SampleValidator()
        {
            RuleFor(x => x.Description).NotNull().WithMessage("{0} cannot be null!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("{0} cannot be empty!");
            RuleFor(x => x.Description).MinimumLength(3).WithMessage("{3} must have at least {0} caracters!");
            RuleFor(x => x.Description).MaximumLength(100).WithMessage("{3} must have a maximum of {1} caracters!");
        }
    }
}
