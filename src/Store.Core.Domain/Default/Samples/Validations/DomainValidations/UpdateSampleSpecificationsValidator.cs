using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using Store.Core.Domain.Default.Samples.Entities;
using Store.Core.Domain.Default.Samples.Specifications;
using NetDevPack.Specification;

namespace Store.Core.Domain.Default.Samples.Validations.DomainValidations
{
    public class UpdateSampleSpecificationsValidator : DomainValidator<Sample>
    {
        public UpdateSampleSpecificationsValidator(
            SampleDescriptionAlreadyExistsSpecification sampleDescriptionAlreadyExistsSpecification
        )
        {
            Add("sampleDescriptionAlreadyExistsSpecification", new DomainRule<Sample>(sampleDescriptionAlreadyExistsSpecification.Not(), sampleDescriptionAlreadyExistsSpecification.ToString()));
        }
    }
}
