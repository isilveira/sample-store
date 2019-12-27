﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using StoreAPI.Core.Application.Interfaces.Infrastructures.Data;
using System.Threading;
using System.Threading.Tasks;

namespace StoreAPI.Core.Application.Orders.Queries.GetOrdersByFilter
{
    public class GetOrdersByFilterQueryHandler : IRequestHandler<GetOrdersByFilterQuery, GetOrdersByFilterQueryResponse>
    {
        private IStoreContext Context { get; set; }
        public GetOrdersByFilterQueryHandler(IStoreContext context)
        {
            Context = context;
        }
        public async Task<GetOrdersByFilterQueryResponse> Handle(GetOrdersByFilterQuery request, CancellationToken cancellationToken)
        {
            int resultCount = 0;

            var data = await Context.Orders
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return new GetOrdersByFilterQueryResponse(request, data, resultCount: resultCount);
        }
    }
}
