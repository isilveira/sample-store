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

namespace Store.Core.Domain.Contexts.Default.Entities.Samples.Services.DeleteSample
{
    [InheritStringLocalizer(typeof(EntitiesSamples), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesDefault), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class DeleteSampleServiceRequestHandler
        : DomainServiceRequestHandler<Sample, DeleteSampleServiceRequest>
    {
        private IDefaultDbContextWriter Writer { get; set; }
        public DeleteSampleServiceRequestHandler(
            IDefaultDbContextWriter writer,
            IStringLocalizer<DeleteSampleServiceRequestHandler> localizer,
            SampleValidator entityValidator,
            DeleteSampleSpecificationsValidator domainValidator
        ) : base(localizer, entityValidator, domainValidator)
        {
            Writer = writer;
        }

        public override async Task<Sample> Handle(DeleteSampleServiceRequest request, CancellationToken cancellationToken)
        {
            ValidateEntity(request.Payload);

            ValidateDomain(request.Payload);

            Writer.Remove(request.Payload);

            return request.Payload;
        }
    }
}
