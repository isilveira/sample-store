using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;

namespace StoreAPI.Core.Application.Categories.Commands.PatchCategory
{
    public class PatchCategoryCommand : RequestBase<Category, PatchCategoryCommandResponse>
    {
        public PatchCategoryCommand()
        {
            ConfigKeys(x => x.CategoryID);

            ConfigSuppressedProperties(x => x.LeafCategories);
            ConfigSuppressedProperties(x => x.RootCategory);
            ConfigSuppressedProperties(x => x.Products);
        }
    }
}
