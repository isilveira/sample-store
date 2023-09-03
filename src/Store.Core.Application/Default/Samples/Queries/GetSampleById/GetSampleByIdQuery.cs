﻿using BAYSOFT.Abstractions.Core.Application;
using Store.Core.Domain.Default.Samples.Entities;
using FluentValidation;

namespace Store.Core.Application.Default.Samples.Queries
{
    public class GetSampleByIdQuery : ApplicationRequest<Sample, GetSampleByIdQueryResponse>
    {
        public GetSampleByIdQuery()
        {
            ConfigKeys(x => x.Id);

            ConfigSuppressedProperties(x => x.Id);
            // ConfigSuppressedResponseProperties(x => x.Id);

            Validator.RuleFor(x => x.Id).NotEmpty().WithMessage("{0} is required!");
        }
    }
}