using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using Microsoft.Extensions.Localization;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Entity;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Resources;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Validations.DomainValidations;
using Store.Core.Domain.Contexts.Store.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Contexts.Store.Resources;
using Store.Core.Domain.Resources;
using Store.Core.Domain.Validations.EntityValidations.Default;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Domain.Contexts.Store.Entities.Customers.Services.CreateCustomer
{
    [InheritStringLocalizer(typeof(EntitiesCustomers), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class CreateCustomerServiceRequestHandler
        : DomainServiceRequestHandler<Customer, CreateCustomerServiceRequest>
    {
        private IStoreDbContextWriter Writer { get; set; }
        public CreateCustomerServiceRequestHandler(
            IStoreDbContextWriter writer,
            IStringLocalizer<CreateCustomerServiceRequestHandler> localizer,
            CustomerValidator entityValidator,
            CreateCustomerSpecificationsValidator domainValidator
        ) : base(localizer, entityValidator, domainValidator)
        {
            Writer = writer;
        }

        public override async Task<Customer> Handle(CreateCustomerServiceRequest request, CancellationToken cancellationToken)
        {
            ValidateEntity(request.Payload);

            ValidateDomain(request.Payload);

            await Writer.AddAsync(request.Payload);

            return request.Payload;
        }
    }
}
