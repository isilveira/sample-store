using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
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

namespace Store.Core.Domain.Contexts.Store.Entities.Customers.Services.UpdateCustomer
{
    [InheritStringLocalizer(typeof(EntitiesCustomers), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class UpdateCustomerServiceRequestHandler
        : DomainServiceRequestHandler<Customer, UpdateCustomerServiceRequest>
    {
        private IStoreDbContextWriter Writer { get; set; }
        public UpdateCustomerServiceRequestHandler(
            IStoreDbContextWriter writer,
            IStringLocalizer<UpdateCustomerServiceRequestHandler> localizer,
            CustomerValidator entityValidator,
            UpdateCustomerSpecificationsValidator domainValidator
        ) : base(localizer, entityValidator, domainValidator)
        {
            Writer = writer;
        }

        public override async Task<Customer> Handle(UpdateCustomerServiceRequest request, CancellationToken cancellationToken)
        {
            ValidateEntity(request.Payload);

            ValidateDomain(request.Payload);

            return request.Payload;
        }
    }
}
