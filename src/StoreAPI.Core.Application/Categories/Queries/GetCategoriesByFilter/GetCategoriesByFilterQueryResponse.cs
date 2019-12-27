﻿using ModelWrapper;
using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;

namespace StoreAPI.Core.Application.Categories.Queries.GetCategoriesByFilter
{
    public class GetCategoriesByFilterQueryResponse : ResponseBase<Category>
    {
        public GetCategoriesByFilterQueryResponse(WrapRequest<Category> request, object data, string message = null, long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
