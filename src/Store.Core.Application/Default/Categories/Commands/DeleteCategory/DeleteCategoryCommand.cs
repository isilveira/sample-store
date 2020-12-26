using Store.Core.Domain.Entities.Default;

namespace Store.Core.Application.Default.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : ApplicationRequest<Category, DeleteCategoryCommandResponse>
    {
        public DeleteCategoryCommand()
        {
            ConfigKeys(x => x.Id);

            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);
        }
    }
}
