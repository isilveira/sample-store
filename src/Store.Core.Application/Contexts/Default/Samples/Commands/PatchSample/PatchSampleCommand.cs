using BAYSOFT.Abstractions.Core.Application;
using FluentValidation;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Entity;

namespace Store.Core.Application.Contexts.Default.Samples.Commands.PatchSample
{
    public class PatchSampleCommand : ApplicationRequest<Sample, PatchSampleCommandResponse>
    {
        public PatchSampleCommand()
        {
            ConfigKeys(x => x.Id);

            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);
            Validator.RuleFor(x => x.Id).NotEqual(0).WithMessage("'{0}' is required!");
            Validator.RuleFor(x => x.Description).NotEmpty().WithMessage("'{0}' is required!");
        }
    }
}
