using BAYSOFT.Abstractions.Core.Application;
using FluentValidation;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Entity;

namespace Store.Core.Application.Contexts.Default.Samples.Commands.DeleteSample
{
    public class DeleteSampleCommand : ApplicationRequest<Sample, DeleteSampleCommandResponse>
    {
        public DeleteSampleCommand()
        {
            ConfigKeys(x => x.Id);

            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);

            Validator.RuleFor(x => x.Id).NotEqual(0).WithMessage("'{0}' is required!");
        }
    }
}
