using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using FluentValidation;
using Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Entity;
using System;

namespace Store.Core.Domain.Validations.EntityValidations.Default
{
    public class OrderedProductValidator : EntityValidator<OrderedProduct>
    {
        public OrderedProductValidator()
        {
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("'{2}' must be greater than '{0}'!");
            RuleFor(x => x.Value).GreaterThan(0).WithMessage("'{2}' must be greater than '{0}'!");
            RuleFor(x => x.RegisteredAt).GreaterThanOrEqualTo(Convert.ToDateTime("2023-01-01")).WithMessage("'{2}' must be greater than or equal to '{0}'!");
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("'{2}' must be greater than '{0}'!");
            RuleFor(x => x.OrderId).GreaterThan(0).WithMessage("'{2}' must be greater than '{0}'!");
        }
    }
}
