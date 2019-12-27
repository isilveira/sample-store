using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;

namespace StoreAPI.Core.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : RequestBase<Category, DeleteCategoryCommandResponse>
    {
        public DeleteCategoryCommand()
        {
            ConfigKeys(x => x.CategoryID);

            ConfigSuppressedProperties(x => x.LeafCategories);
            ConfigSuppressedProperties(x => x.RootCategory);
            ConfigSuppressedProperties(x => x.Products);
        }
    }
}
