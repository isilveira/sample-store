using BAYSOFT.Abstractions.Core.Application;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Entity;

namespace Store.Core.Application.Contexts.Default.Samples.Queries.GetSamplesByFilter
{
    public class GetSamplesByFilterQuery : ApplicationRequest<Sample, GetSamplesByFilterQueryResponse>
    {
        public GetSamplesByFilterQuery()
        {
            ConfigKeys(x => x.Id);

            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
