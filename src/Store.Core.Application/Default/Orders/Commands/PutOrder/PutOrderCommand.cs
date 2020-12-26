using Store.Core.Domain.Entities.Default;

namespace Store.Core.Application.Default.Orders.Commands.PutOrder
{
    public class PutOrderCommand : ApplicationRequest<Order, PutOrderCommandResponse>
    {
        public PutOrderCommand()
        {
            ConfigKeys(x => x.Id);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
