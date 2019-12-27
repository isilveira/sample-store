using ModelWrapper;
using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;

namespace StoreAPI.Core.Application.Categories.Commands.PutCategory
{
    public class PutCategoryCommandResponse : ResponseBase<Category>
    {
        public PutCategoryCommandResponse(WrapRequest<Category> request, object data, string message = null, long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
