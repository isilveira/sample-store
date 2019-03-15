using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreAPI.Core.Application.Interfaces.Contexts;
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
            int resultCount = await Context.Products.CountAsync();

            var results = await Context.Products.ToListAsync(cancellationToken);

            return new GetProductsByFilterQueryResponse
            {
                Request = request,
                ResultCount = resultCount,
                Data = results.Select(result => new GetProductsByFilterQueryResponseDTO
                {
                    ProductID = result.ProductID,
                    CategoryID = result.CategoryID,
                    Name = result.Name,
                    Description = result.Description,
                    Specifications = result.Specifications,
                    RegistrationDate = result.RegistrationDate,
                    Value = result.Value,
                    Amount = result.Amount,
                    IsVisible = result.IsVisible
                }).ToList()
            };
        }
    }
}
