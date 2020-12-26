using Store.Core.Domain.Entities.Default;

namespace Store.Core.Application.Default.Categories.Commands.PutCategory
{
    public class PutCategoryCommand : ApplicationRequest<Category, PutCategoryCommandResponse>
    {
        public PutCategoryCommand()
        {
            ConfigKeys(x => x.Id);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
