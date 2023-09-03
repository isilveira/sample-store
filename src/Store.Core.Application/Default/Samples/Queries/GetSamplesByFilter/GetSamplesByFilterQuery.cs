using BAYSOFT.Abstractions.Core.Application;
using Store.Core.Domain.Default.Samples.Entities;

namespace Store.Core.Application.Default.Samples.Queries
{
    public class GetSamplesByFilterQuery : ApplicationRequest<Sample, GetSamplesByFilterQueryResponse>
    {
        public GetSamplesByFilterQuery()
        {
            ConfigKeys(x => x.Id);

            // ConfigSuppressedProperties(x => x.Id);
            // ConfigSuppressedResponseProperties(x => x.Id);

            //Validator.RuleFor(x => x.prop).NotEmpty().WithMessage("{0} is required!");
        }
    }
}