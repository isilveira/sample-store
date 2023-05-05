﻿using Store.Presentations.WebAPI.Abstractions.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Store.Core.Application.Contexts.Store.Products.Commands.DeleteProduct;
using Store.Core.Application.Contexts.Store.Products.Commands.PatchProduct;
using Store.Core.Application.Contexts.Store.Products.Commands.PostProduct;
using Store.Core.Application.Contexts.Store.Products.Commands.PutProduct;
using Store.Core.Application.Contexts.Store.Products.Queries.GetProductById;
using Store.Core.Application.Contexts.Store.Products.Queries.GetProductsByFilter;

namespace Store.Resources
{
    public class ProductsController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetProductsByFilterQueryResponse>> Get(GetProductsByFilterQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetProductByIdQueryResponse>> Get(GetProductByIdQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<PostProductCommandResponse>> Post(PostProductCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PutProductCommandResponse>> Put(PutProductCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<PatchProductCommandResponse>> Patch(PatchProductCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteProductCommandResponse>> Delete(DeleteProductCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }
    }
}
