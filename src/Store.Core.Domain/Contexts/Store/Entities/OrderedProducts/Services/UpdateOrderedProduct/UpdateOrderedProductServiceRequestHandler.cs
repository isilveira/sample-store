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

namespace Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Services.UpdateOrderedProduct
{
    [InheritStringLocalizer(typeof(EntitiesOrderedProducts), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class UpdateOrderedProductServiceRequestHandler
         : DomainServiceRequestHandler<OrderedProduct, UpdateOrderedProductServiceRequest>
    {
        private IStoreDbContextWriter Writer { get; set; }
        public UpdateOrderedProductServiceRequestHandler(
            IStoreDbContextWriter writer,
            IStringLocalizer<UpdateOrderedProductServiceRequestHandler> localizer,
            OrderedProductValidator entityValidator,
            UpdateOrderedProductSpecificationsValidator domainValidator
        ) : base(localizer, entityValidator, domainValidator)
        {
            Writer = writer;
        }

        public override async Task<OrderedProduct> Handle(UpdateOrderedProductServiceRequest request, CancellationToken cancellationToken)
        {
            ValidateEntity(request.Payload);

            ValidateDomain(request.Payload);

            return request.Payload;
        }
    }
}
