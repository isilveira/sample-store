using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using FluentValidation;
using Store.Core.Domain.Contexts.Store.Entities.Products.Entity;
using System;

namespace Store.Core.Domain.Validations.EntityValidations.Default
{
    public class ProductValidator : EntityValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{0} cannot be null!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("{0} cannot be empty!");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("{3} must have at least {0} characters!");
            RuleFor(x => x.Name).MaximumLength(128).WithMessage("{3} must have a maximum of {1} characters!");

            RuleFor(x => x.Description).NotNull().WithMessage("{0} cannot be null!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("{0} cannot be empty!");
            RuleFor(x => x.Description).MinimumLength(3).WithMessage("{3} must have at least {0} characters!");
            RuleFor(x => x.Description).MaximumLength(512).WithMessage("{3} must have a maximum of {1} characters!");

            RuleFor(x => x.Specifications).NotNull().WithMessage("{0} cannot be null!");
            RuleFor(x => x.Specifications).NotEmpty().WithMessage("{0} cannot be empty!");
            RuleFor(x => x.Specifications).MinimumLength(3).WithMessage("{3} must have at least {0} characters!");

            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("'{2}' must be greater than '{0}'!");
            RuleFor(x => x.Value).GreaterThan(0).WithMessage("'{2}' must be greater than '{0}'!");
            
            RuleFor(x => x.RegisteredAt).GreaterThanOrEqualTo(Convert.ToDateTime("2023-01-01")).WithMessage("'{2}' must be greater than or equal to '{0}'!");
            
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("'{2}' must be greater than '{0}'!");
        }
    }
}
