using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;

namespace StoreAPI.Core.Application.Categories.Commands.PostCategory
{
    public class PostCategoryCommand : RequestBase<Category, PostCategoryCommandResponse>
    {
        public PostCategoryCommand()
        {
            ConfigKeys(x => x.CategoryID);

            ConfigSuppressedProperties(x => x.LeafCategories);
            ConfigSuppressedProperties(x => x.RootCategory);
            ConfigSuppressedProperties(x => x.Products);
        }
    }
}
