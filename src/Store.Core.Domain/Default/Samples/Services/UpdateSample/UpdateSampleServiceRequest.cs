using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using Store.Core.Domain.Default.Samples.Entities;

namespace Store.Core.Domain.Default.Samples.Services
{
    public class UpdateSampleServiceRequest : DomainServiceRequest<Sample>
    {
        public UpdateSampleServiceRequest(Sample payload) : base(payload)
        {
        }
    }
}