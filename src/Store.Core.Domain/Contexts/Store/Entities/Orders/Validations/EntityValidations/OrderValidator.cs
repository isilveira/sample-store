using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using FluentValidation;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Entity;
using System;

namespace Store.Core.Domain.Validations.EntityValidations.Default
{
    public class OrderValidator : EntityValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x.RegisteredAt).GreaterThanOrEqualTo(Convert.ToDateTime("2023-01-01")).WithMessage("'{2}' must be greater than or equal to '{0}'!");
            RuleFor(x => x.ConfirmedAt).GreaterThan(x => x.RegisteredAt).WithMessage("'{2}' must be greater than '{0}'!");
            RuleFor(x => x.CancelledAt).GreaterThan(x => x.RegisteredAt).WithMessage("'{2}' must be greater than '{0}'!");
        }
    }
}
