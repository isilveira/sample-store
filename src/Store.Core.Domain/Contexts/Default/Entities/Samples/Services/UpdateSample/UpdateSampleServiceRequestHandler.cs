using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using Microsoft.Extensions.Localization;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Entity;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Resources;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Validations.DomainValidations;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Validations.EntityValidations.Default;
using Store.Core.Domain.Contexts.Default.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Contexts.Default.Resources;
using Store.Core.Domain.Resources;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Domain.Contexts.Default.Entities.Samples.Services.UpdateSample
{
    [InheritStringLocalizer(typeof(EntitiesSamples), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesDefault), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class UpdateSampleServiceRequestHandler
        : DomainServiceRequestHandler<Sample, UpdateSampleServiceRequest>
    {
        private IDefaultDbContextWriter Writer { get; set; }
        public UpdateSampleServiceRequestHandler(
            IDefaultDbContextWriter writer,
            IStringLocalizer<UpdateSampleServiceRequestHandler> localizer,
            SampleValidator entityValidator,
            UpdateSampleSpecificationsValidator domainValidator
        ) : base(localizer, entityValidator, domainValidator)
        {
            Writer = writer;
        }

        public override async Task<Sample> Handle(UpdateSampleServiceRequest request, CancellationToken cancellationToken)
        {
            ValidateEntity(request.Payload);

            ValidateDomain(request.Payload);

            return request.Payload;
        }
    }
}
