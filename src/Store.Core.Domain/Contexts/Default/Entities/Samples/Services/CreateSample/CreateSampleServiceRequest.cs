using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Entity;

namespace Store.Core.Domain.Contexts.Default.Entities.Samples.Services.CreateSample
{
    public class CreateSampleServiceRequest : DomainServiceRequest<Sample>
    {
        public CreateSampleServiceRequest(Sample payload) : base(payload)
        {
        }
    }
}
