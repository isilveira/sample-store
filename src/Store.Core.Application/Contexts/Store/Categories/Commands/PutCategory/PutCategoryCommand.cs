using BAYSOFT.Abstractions.Core.Application;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Entity;

namespace Store.Core.Application.Contexts.Store.Categories.Commands.PutCategory
{
    public class PutCategoryCommand : ApplicationRequest<Category, PutCategoryCommandResponse>
    {
        public PutCategoryCommand()
        {
            ConfigKeys(x => x.Id);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.RootCategory);
            ConfigSuppressedProperties(x => x.SubCategories);
            ConfigSuppressedProperties(x => x.Products);

            ConfigSuppressedResponseProperties(x => x.RootCategory);
            ConfigSuppressedResponseProperties(x => x.SubCategories);
            ConfigSuppressedResponseProperties(x => x.Products);
        }
    }
}
