using BAYSOFT.Abstractions.Core.Application;
using ModelWrapper;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Entity;
using System;
using System.Collections.Generic;

namespace Store.Core.Application.Contexts.Store.Categories.Queries.GetCategoriesByFilter
{
    public class GetCategoriesByFilterQueryResponse : ApplicationResponse<Category>
    {
        public GetCategoriesByFilterQueryResponse(Tuple<int, int, WrapRequest<Category>, Dictionary<string, object>, Dictionary<string, object>, string, long?> tuple) : base(tuple)
        {
        }

        public GetCategoriesByFilterQueryResponse(WrapRequest<Category> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
