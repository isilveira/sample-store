﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using StoreAPI.Core.Application.Interfaces.Infrastructures.Data;
using System.Threading;
using System.Threading.Tasks;

namespace StoreAPI.Core.Application.Customers.Queries.GetCustomersByFilter
{
    public class GetCustomersByFilterQueryHandler : IRequestHandler<GetCustomersByFilterQuery, GetCustomersByFilterQueryResponse>
    {
        private IStoreContext Context { get; set; }
        public GetCustomersByFilterQueryHandler(IStoreContext context)
        {
            Context = context;
        }
        public async Task<GetCustomersByFilterQueryResponse> Handle(GetCustomersByFilterQuery request, CancellationToken cancellationToken)
        {
            int resultCount = 0;

            var results = await Context.Customers
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return new GetCustomersByFilterQueryResponse(request, results, resultCount: resultCount);
        }
    }
}
