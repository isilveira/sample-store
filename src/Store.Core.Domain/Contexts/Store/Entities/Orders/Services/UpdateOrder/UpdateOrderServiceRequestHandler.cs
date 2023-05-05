using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using Microsoft.Extensions.Localization;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Entity;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Resources;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Services.CreateOrder;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Validations.DomainValidations;
using Store.Core.Domain.Contexts.Store.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Contexts.Store.Resources;
using Store.Core.Domain.Resources;
using Store.Core.Domain.Validations.EntityValidations.Default;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Domain.Contexts.Store.Entities.Orders.Services.UpdateOrder
{
    [InheritStringLocalizer(typeof(EntitiesOrders), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class UpdateOrderServiceRequestHandler
        : DomainServiceRequestHandler<Order, UpdateOrderServiceRequest>
    {
        private IStoreDbContextWriter Writer { get; set; }
        public UpdateOrderServiceRequestHandler(
            IStoreDbContextWriter writer,
            IStringLocalizer<CreateOrderServiceRequestHandler> localizer,
            OrderValidator entityValidator,
            UpdateOrderSpecificationsValidator domainValidator
        ) : base(localizer, entityValidator, domainValidator)
        {
            Writer = writer;
        }

        public override async Task<Order> Handle(UpdateOrderServiceRequest request, CancellationToken cancellationToken)
        {
            ValidateEntity(request.Payload);

            ValidateDomain(request.Payload);

            return request.Payload;
        }
    }
}
