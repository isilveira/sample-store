using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using Microsoft.Extensions.Localization;
using Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Entity;
using Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Resources;
using Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Validations.DomainValidations;
using Store.Core.Domain.Contexts.Store.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Contexts.Store.Resources;
using Store.Core.Domain.Resources;
using Store.Core.Domain.Validations.EntityValidations.Default;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Services.CreateOrderedProduct
{
    [InheritStringLocalizer(typeof(EntitiesOrderedProducts), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class CreateOrderedProductServiceRequestHandler
         : DomainServiceRequestHandler<OrderedProduct, CreateOrderedProductServiceRequest>
    {
        private IStoreDbContextWriter Writer { get; set; }
        public CreateOrderedProductServiceRequestHandler(
            IStoreDbContextWriter writer,
            IStringLocalizer<CreateOrderedProductServiceRequestHandler> localizer,
            OrderedProductValidator entityValidator,
            CreateOrderedProductSpecificationsValidator domainValidator
        ) : base(localizer, entityValidator, domainValidator)
        {
            Writer = writer;
        }

        public override async Task<OrderedProduct> Handle(CreateOrderedProductServiceRequest request, CancellationToken cancellationToken)
        {
            ValidateEntity(request.Payload);

            ValidateDomain(request.Payload);

            await Writer.AddAsync(request.Payload);

            return request.Payload;
        }
    }
}
