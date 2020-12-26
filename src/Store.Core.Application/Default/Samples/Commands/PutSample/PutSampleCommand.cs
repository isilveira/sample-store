using Store.Core.Domain.Entities.Default;

namespace Store.Core.Application.Default.Samples.Commands.PutSample
{
    public class PutSampleCommand : ApplicationRequest<Sample, PutSampleCommandResponse>
    {
        public PutSampleCommand()
        {
            ConfigKeys(x => x.Id);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
