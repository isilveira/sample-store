using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Entity;

namespace Store.Core.Domain.Contexts.Default.Entities.Samples.Validations.DomainValidations
{
    public class DeleteSampleSpecificationsValidator : DomainValidator<Sample>
    {
        public DeleteSampleSpecificationsValidator()
        {
        }
    }
}
