﻿using MediatR;
using ModelWrapper.Extensions.Post;
using Store.Core.Application.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Application.Images.Commands.PostImage
{
    public class PostImageCommandHandler : IRequestHandler<PostImageCommand, PostImageCommandResponse>
    {
        private IStoreContext Context { get; set; }
        public PostImageCommandHandler(IStoreContext context)
        {
            Context = context;
        }
        public async Task<PostImageCommandResponse> Handle(PostImageCommand request, CancellationToken cancellationToken)
        {
            var data = request.Post();

            await Context.Images.AddAsync(data);

            await Context.SaveChangesAsync();

            return new PostImageCommandResponse(request, data, resultCount: 1);
        }
    }
}
