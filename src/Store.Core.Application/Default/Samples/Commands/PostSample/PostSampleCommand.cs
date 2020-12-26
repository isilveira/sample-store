using Store.Core.Domain.Entities.Default;

namespace Store.Core.Application.Default.Samples.Commands.PostSample
{
    public class PostSampleCommand : ApplicationRequest<Sample, PostSampleCommandResponse>
    {
        public PostSampleCommand()
        {
            ConfigKeys(x => x.Id);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);       
        }
    }
}
