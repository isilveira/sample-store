using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using Store.Core.Domain.Default.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Default.Resources;
using Store.Core.Domain.Default.Samples.Entities;
using Store.Core.Domain.Default.Samples.Resources;
using Store.Core.Domain.Default.Samples.Validations.DomainValidations;
using Store.Core.Domain.Default.Samples.Validations.EntityValidations;
using Store.Core.Domain.Resources;
using Microsoft.Extensions.Localization;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Domain.Default.Samples.Services.DeleteSample
{
    [InheritStringLocalizer(typeof(Messages), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesDefault), Priority = 1)]
    [InheritStringLocalizer(typeof(EntitiesSamples), Priority = 2)]
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
