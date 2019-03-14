using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Core.Application.Categories.Queries.GetCategoriesByFilter
{
    public class GetCategoriesByFilterQueryResponse
    {
        public GetCategoriesByFilterQuery Request { get; set; }
        public int ResultCount { get; set; }
        public List<GetCategoriesByFilterQueryResponseDTO> Data { get; set; }
    }
}
