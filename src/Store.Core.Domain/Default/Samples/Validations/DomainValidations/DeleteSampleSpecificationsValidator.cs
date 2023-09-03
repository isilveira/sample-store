using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using Store.Core.Domain.Default.Samples.Entities;

namespace Store.Core.Domain.Default.Samples.Validations.DomainValidations
{
    public class DeleteSampleSpecificationsValidator : DomainValidator<Sample>
    {
        public DeleteSampleSpecificationsValidator()
        {
        }
    }
}
