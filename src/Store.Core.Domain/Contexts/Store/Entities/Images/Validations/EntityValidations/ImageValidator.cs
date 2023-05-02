using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using FluentValidation;
using Store.Core.Domain.Contexts.Store.Entities.Images.Entity;

namespace Store.Core.Domain.Validations.EntityValidations.Default
{
    public class ImageValidator : EntityValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(x => x.Url).NotNull().WithMessage("{0} cannot be null!");
            RuleFor(x => x.Url).NotEmpty().WithMessage("{0} cannot be empty!");
            RuleFor(x => x.Url).MinimumLength(3).WithMessage("{3} must have at least {0} characters!");
            RuleFor(x => x.Url).MaximumLength(512).WithMessage("{3} must have a maximum of {1} characters!");

            RuleFor(x => x.MimeType).NotNull().WithMessage("{0} cannot be null!");
            RuleFor(x => x.MimeType).NotEmpty().WithMessage("{0} cannot be empty!");
            RuleFor(x => x.MimeType).MinimumLength(3).WithMessage("{3} must have at least {0} characters!");
            RuleFor(x => x.MimeType).MaximumLength(32).WithMessage("{3} must have a maximum of {1} characters!");
        }
    }
}
