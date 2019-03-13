using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Core.Application.Products.Queries.GetProductsByFilter
{
    public class GetProductsByFilterQueryResponse
    {
        public GetProductsByFilterQuery Request { get; set; }
        public int ResultCount { get; set; }
        public List<GetProductsByFilterQueryResponseDTO> Data { get; set; }
    }
}
