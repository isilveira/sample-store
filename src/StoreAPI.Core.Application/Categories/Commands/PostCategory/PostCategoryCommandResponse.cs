using ModelWrapper;
using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;

namespace StoreAPI.Core.Application.Categories.Commands.PostCategory
{
    public class PostCategoryCommandResponse : ResponseBase<Category>
    {
        public PostCategoryCommandResponse(WrapRequest<Category> request, object data, string message = null, long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
