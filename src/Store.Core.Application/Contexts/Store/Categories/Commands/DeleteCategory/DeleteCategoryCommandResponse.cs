using BAYSOFT.Abstractions.Core.Application;
using ModelWrapper;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Entity;
using System;
using System.Collections.Generic;

namespace Store.Core.Application.Contexts.Store.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandResponse : ApplicationResponse<Category>
    {
        public DeleteCategoryCommandResponse(Tuple<int, int, WrapRequest<Category>, Dictionary<string, object>, Dictionary<string, object>, string, long?> tuple) : base(tuple)
        {
        }

        public DeleteCategoryCommandResponse(WrapRequest<Category> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
