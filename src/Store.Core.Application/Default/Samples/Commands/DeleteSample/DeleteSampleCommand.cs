﻿using BAYSOFT.Abstractions.Core.Application;
using Store.Core.Domain.Default.Samples.Entities;
using FluentValidation;

namespace Store.Core.Application.Default.Samples.Commands
{
    public class DeleteSampleCommand : ApplicationRequest<Sample, DeleteSampleCommandResponse>
    {
        public DeleteSampleCommand()
        {
            ConfigKeys(x => x.Id);

            ConfigSuppressedProperties(x => x.Id);

            Validator.RuleFor(x => x.Id).NotEqual(0).WithMessage("'{0}' is required!");
        }
    }
}