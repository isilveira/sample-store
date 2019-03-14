using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Core.Application.Categories.Queries.GetCategoriesByFilter
{
    public class GetCategoriesByFilterQuery : IRequest<GetCategoriesByFilterQueryResponse>
    {
        public GetCategoriesByFilterQuery()
        {
        }
    }
}
