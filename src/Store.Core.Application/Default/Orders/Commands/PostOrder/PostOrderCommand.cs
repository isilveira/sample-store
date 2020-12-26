using Store.Core.Domain.Entities.Default;

namespace Store.Core.Application.Default.Orders.Commands.PostOrder
{
    public class PostOrderCommand : ApplicationRequest<Order, PostOrderCommandResponse>
    {
        public PostOrderCommand()
        {
            ConfigKeys(x => x.Id);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);       
        }
    }
}
