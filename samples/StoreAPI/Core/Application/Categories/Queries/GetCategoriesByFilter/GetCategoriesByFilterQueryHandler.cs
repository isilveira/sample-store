using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreAPI.Core.Application.Interfaces.Contexts;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreAPI.Core.Application.Categories.Queries.GetCategoriesByFilter
{
    public class GetCategoriesByFilterQueryHandler : IRequestHandler<GetCategoriesByFilterQuery, GetCategoriesByFilterQueryResponse>
    {
        private IStoreContext Context { get; set; }
        public GetCategoriesByFilterQueryHandler(IStoreContext context)
        {
            Context = context;
        }
        public async Task<GetCategoriesByFilterQueryResponse> Handle(GetCategoriesByFilterQuery request, CancellationToken cancellationToken)
        {
            int resultCount = await Context.Categories.CountAsync();
            var results = await Context.Categories.ToListAsync();

            return new GetCategoriesByFilterQueryResponse
            {
                Request = request,
                ResultCount = resultCount,
                Data = results.Select(result => new GetCategoriesByFilterQueryResponseDTO
                {
                    CategoryID = result.CategoryID,
                    RootCategoryID = result.RootCategoryID,
                    Name = result.Name,
                    Description = result.Description
                }).ToList()
            };
        }
    }
}
