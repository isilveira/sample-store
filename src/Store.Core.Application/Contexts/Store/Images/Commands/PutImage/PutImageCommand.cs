using BAYSOFT.Abstractions.Core.Application;
using Store.Core.Domain.Contexts.Store.Entities.Images.Entity;

namespace Store.Core.Application.Contexts.Store.Images.Commands.PutImage
{
    public class PutImageCommand : ApplicationRequest<Image, PutImageCommandResponse>
    {
        public PutImageCommand()
        {
            ConfigKeys(x => x.Id);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Product);

            ConfigSuppressedResponseProperties(x => x.Product);
        }
    }
}
