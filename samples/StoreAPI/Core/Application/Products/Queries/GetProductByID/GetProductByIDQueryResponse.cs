using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Core.Application.Products.Queries.GetProductByID
{
    public class GetProductByIDQueryResponse
    {
        public GetProductByIDQuery Request { get; set; }
        public GetProductByIDQueryResponseDTO Data { get; set; }
    }
}
