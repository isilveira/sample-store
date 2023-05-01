using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Entity;

namespace Store.Core.Domain.Contexts.Default.Entities.Samples.Services.DeleteSample
{
    public class DeleteSampleServiceRequest : DomainServiceRequest<Sample>
    {
        public DeleteSampleServiceRequest(Sample payload) : base(payload)
        {
        }
    }
}