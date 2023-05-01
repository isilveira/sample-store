﻿using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Entity;
using Store.Core.Domain.Validations.Specifications.Default.Samples;

namespace Store.Core.Domain.Contexts.Default.Entities.Samples.Validations.DomainValidations
{
    public class UpdateSampleSpecificationsValidator : DomainValidator<Sample>
    {
        public UpdateSampleSpecificationsValidator(
            SampleDescriptionAlreadyExistsSpecification sampleDescriptionAlreadyExistsSpecification
        )
        {
            base.Add("SanpleMustBeUnique", new DomainRule<Sample>(sampleDescriptionAlreadyExistsSpecification.Not(), "A register with this description already exists!"));
        }
    }
}
