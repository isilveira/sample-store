﻿using MediatR;
using StoreAPI.Core.Application.Interfaces;
using StoreAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreAPI.Core.Application.Categories.Commands.PostCategory
{
    public class PostCategoryCommandHandler : IRequestHandler<PostCategoryCommand, PostCategoryCommandResponse>
    {
        public IStoreContext Context { get; set; }
        public PostCategoryCommandHandler(IStoreContext context)
        {
            Context = context;
        }
        public async Task<PostCategoryCommandResponse> Handle(PostCategoryCommand request, CancellationToken cancellationToken)
        {
            var data = new Category
            {
                RootCategoryID = request.RootCategoryID,
                Name = request.Name,
                Description = request.Description,
            };

            await Context.Categories.AddAsync(data);

            await Context.SaveChangesAsync();

            return new PostCategoryCommandResponse
            {
                Request = request,
                Message = "Successful operation!",
                Data = new PostCategoryCommandResponseDTO
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
