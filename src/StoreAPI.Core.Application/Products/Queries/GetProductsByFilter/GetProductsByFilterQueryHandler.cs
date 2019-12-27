using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using StoreAPI.Core.Application.Interfaces.Infrastructures.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreAPI.Core.Application.Products.Queries.GetProductsByFilter
{
    public class GetProductsByFilterQueryHandler : IRequestHandler<GetProductsByFilterQuery, GetProductsByFilterQueryResponse>
    {
        private IStoreContext Context { get; set; }
        public GetProductsByFilterQueryHandler(IStoreContext context)
        {
            Context = context;
        }

        public async Task<GetProductsByFilterQueryResponse> Handle(GetProductsByFilterQuery request, CancellationToken cancellationToken)
        {
            int resultCount = 0;

            var data = await Context.Products
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return new GetProductsByFilterQueryResponse(request, data, resultCount: resultCount);
        }
    }
}
