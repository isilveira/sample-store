using Store.Core.Domain.Entities.Default;

namespace Store.Core.Application.Default.Categories.Commands.PostCategory
{
    public class PostCategoryCommand : ApplicationRequest<Category, PostCategoryCommandResponse>
    {
        public PostCategoryCommand()
        {
            ConfigKeys(x => x.Id);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);       
        }
    }
}
