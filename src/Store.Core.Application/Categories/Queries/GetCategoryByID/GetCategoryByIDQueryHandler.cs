using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Select;
using Store.Core.Application.Interfaces.Infrastructures.Data;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Application.Categories.Queries.GetCategoryByID
{
    public class GetCategoryByIDQueryHandler : IRequestHandler<GetCategoryByIDQuery, GetCategoryByIDQueryResponse>
    {
        private IStoreContext Context { get; set; }
        public GetCategoryByIDQueryHandler(IStoreContext context)
        {
            Context = context;
        }
        public async Task<GetCategoryByIDQueryResponse> Handle(GetCategoryByIDQuery request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.CategoryID);

            var data = await Context.Categories
                .Where(x => x.CategoryID == id)
                .Select(request)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (data == null)
            {
                throw new Exception("Category not found!");
            }

            return new GetCategoryByIDQueryResponse(request, data, resultCount: 1);
        }
    }
}
