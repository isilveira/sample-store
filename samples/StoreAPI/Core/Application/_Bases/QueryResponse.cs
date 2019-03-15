using StoreAPI.Core.Application.Interfaces.Responses;

namespace StoreAPI.Core.Application.Bases
{
    public class QueryResponse<TResponse, TDTO> : Response<TResponse, TDTO>, IQueryResponse<TResponse, TDTO>
    {
        public int ResultCount { get; set; }
    }
}
