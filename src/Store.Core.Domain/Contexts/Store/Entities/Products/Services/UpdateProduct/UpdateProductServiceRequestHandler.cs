using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using Microsoft.Extensions.Localization;
using Store.Core.Domain.Contexts.Store.Entities.Products.Entity;
using Store.Core.Domain.Contexts.Store.Entities.Products.Services.CreateProduct;
using Store.Core.Domain.Contexts.Store.Entities.Products.Validations.DomainValidations;
using Store.Core.Domain.Contexts.Store.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Validations.EntityValidations.Default;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Domain.Contexts.Store.Entities.Products.Services.UpdateProduct
{
    public class UpdateProductServiceRequestHandler
        : DomainServiceRequestHandler<Product, CreateProductServiceRequest>
    {
        private IStoreDbContextWriter Writer { get; set; }
        public UpdateProductServiceRequestHandler(
            IStoreDbContextWriter writer,
            IStringLocalizer<UpdateProductServiceRequestHandler> localizer,
            ProductValidator entityValidator,
            UpdateProductSpecificationsValidator domainValidator
        ) : base(localizer, entityValidator, domainValidator)
        {
            Writer = writer;
        }

        public override async Task<Product> Handle(CreateProductServiceRequest request, CancellationToken cancellationToken)
        {
            ValidateEntity(request.Payload);

            ValidateDomain(request.Payload);

            return request.Payload;
        }
    }
}
