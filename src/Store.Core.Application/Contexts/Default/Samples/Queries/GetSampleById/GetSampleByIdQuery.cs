using BAYSOFT.Abstractions.Core.Application;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Entity;

namespace Store.Core.Application.Contexts.Default.Samples.Queries.GetSampleById
{
    public class GetSampleByIdQuery : ApplicationRequest<Sample, GetSampleByIdQueryResponse>
    {
        public GetSampleByIdQuery()
        {
            ConfigKeys(x => x.Id);

            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}