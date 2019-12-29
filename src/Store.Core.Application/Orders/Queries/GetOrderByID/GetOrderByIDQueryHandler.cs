﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.Core.Application.Interfaces.Infrastructures.Data;

namespace Store.Core.Application.Orders.Queries.GetOrderByID
{
    public class GetOrderByIDQueryHandler : IRequestHandler<GetOrderByIDQuery, GetOrderByIDQueryResponse>
    {
        private IStoreContext Context { get; set; }
        public GetOrderByIDQueryHandler(IStoreContext context)
        {
            Context = context;
        }
        public async Task<GetOrderByIDQueryResponse> Handle(GetOrderByIDQuery request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.OrderID);

            var data = await Context.Orders.AsNoTracking().SingleOrDefaultAsync(x => x.OrderID == id);

            if (data == null)
            {
                throw new Exception("Order not found!");
            }

            return new GetOrderByIDQueryResponse(request, data, resultCount: 1);
        }
    }
}
