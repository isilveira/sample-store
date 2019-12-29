﻿using MediatR;
using ModelWrapper.Extensions.Post;
using Store.Core.Application.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Application.OrderedProducts.Commands.PostOrderedProduct
{
    public class PostOrderedProductCommandHandler : IRequestHandler<PostOrderedProductCommand, PostOrderedProductCommandResponse>
    {
        private IStoreContext Context { get; set; }
        public PostOrderedProductCommandHandler(IStoreContext context)
        {
            Context = context;
        }
        public async Task<PostOrderedProductCommandResponse> Handle(PostOrderedProductCommand request, CancellationToken cancellationToken)
        {
            var data = request.Post();

            data.RegistrationDate = DateTime.UtcNow;

            await Context.OrderedProducts.AddAsync(data);

            await Context.SaveChangesAsync();

            return new PostOrderedProductCommandResponse(request, data, resultCount: 1);
        }
    }
}
