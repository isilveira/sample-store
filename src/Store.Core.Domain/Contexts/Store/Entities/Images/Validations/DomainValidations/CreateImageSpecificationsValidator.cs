﻿using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using Store.Core.Domain.Contexts.Store.Entities.Images.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.Images.Validations.DomainValidations
{
    public class CreateImageSpecificationsValidator : DomainValidator<Image>
    {
        public CreateImageSpecificationsValidator()
        {
        }
    }
}
