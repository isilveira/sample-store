﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreAPI.Core.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreAPI.Core.Application.Categories.Queries.GetCategoryByID
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
            var data = await Context.Categories.SingleOrDefaultAsync(x => x.CategoryID == request.CategoryID);

            if (data == null)
                throw new Exception("Category not found!");

            return new GetCategoryByIDQueryResponse
            {
                Request = request,
                Data = new GetCategoryByIDQueryResponseDTO
                {
                    CategoryID = data.CategoryID,
                    RootCategoryID = data.RootCategoryID,
                    Name = data.Name,
                    Description = data.Description
                }
            };
        }
    }
}
