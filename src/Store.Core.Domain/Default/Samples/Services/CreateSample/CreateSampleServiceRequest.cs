using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using Store.Core.Domain.Default.Samples.Entities;

namespace Store.Core.Domain.Default.Samples.Services
{
    public class CreateSampleServiceRequest : DomainServiceRequest<Sample>
    {
        public CreateSampleServiceRequest(Sample payload) : base(payload)
        {
        }
    }
}