using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Core.Application.Categories.Queries.GetCategoryByID
{
    public class GetCategoryByIDQueryResponse
    {
        public GetCategoryByIDQuery Request { get; set; }
        public GetCategoryByIDQueryResponseDTO Data { get; set; }
    }
}
