using Store.Presentations.WebAPI.Abstractions.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Store.Core.Application.Contexts.Store.OrderedProducts.Commands.DeleteOrderedProduct;
using Store.Core.Application.Contexts.Store.OrderedProducts.Commands.PatchOrderedProduct;
using Store.Core.Application.Contexts.Store.OrderedProducts.Commands.PostOrderedProduct;
using Store.Core.Application.Contexts.Store.OrderedProducts.Commands.PutOrderedProduct;
using Store.Core.Application.Contexts.Store.OrderedProducts.Queries.GetOrderedProductById;
using Store.Core.Application.Contexts.Store.OrderedProducts.Queries.GetOrderedProductsByFilter;

namespace Store.Resources
{
    public class OrderedProductsController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetOrderedProductsByFilterQueryResponse>> Get(GetOrderedProductsByFilterQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetOrderedProductByIdQueryResponse>> Get(GetOrderedProductByIdQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<PostOrderedProductCommandResponse>> Post(PostOrderedProductCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PutOrderedProductCommandResponse>> Put(PutOrderedProductCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<PatchOrderedProductCommandResponse>> Patch(PatchOrderedProductCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteOrderedProductCommandResponse>> Delete(DeleteOrderedProductCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }
    }
}
