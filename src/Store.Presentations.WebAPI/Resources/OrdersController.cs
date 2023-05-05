using Store.Presentations.WebAPI.Abstractions.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Store.Core.Application.Contexts.Store.Orders.Commands.DeleteOrder;
using Store.Core.Application.Contexts.Store.Orders.Commands.PatchOrder;
using Store.Core.Application.Contexts.Store.Orders.Commands.PostOrder;
using Store.Core.Application.Contexts.Store.Orders.Commands.PutOrder;
using Store.Core.Application.Contexts.Store.Orders.Queries.GetOrderById;
using Store.Core.Application.Contexts.Store.Orders.Queries.GetOrdersByFilter;

namespace Store.Resources
{
    public class OrdersController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetOrdersByFilterQueryResponse>> Get(GetOrdersByFilterQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetOrderByIdQueryResponse>> Get(GetOrderByIdQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<PostOrderCommandResponse>> Post(PostOrderCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PutOrderCommandResponse>> Put(PutOrderCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<PatchOrderCommandResponse>> Patch(PatchOrderCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteOrderCommandResponse>> Delete(DeleteOrderCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }
    }
}
