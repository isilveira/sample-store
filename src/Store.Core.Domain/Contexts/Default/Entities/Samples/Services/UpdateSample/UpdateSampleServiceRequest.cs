using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Entity;

namespace Store.Core.Domain.Contexts.Default.Entities.Samples.Services.UpdateSample
{
    public class UpdateSampleServiceRequest : DomainServiceRequest<Sample>
    {
        public UpdateSampleServiceRequest(Sample payload) : base(payload)
        {
        }
    }
}
