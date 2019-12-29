using Microsoft.AspNetCore.Mvc;
using Store.Core.Application.Orders.Commands.DeleteOrder;
using Store.Core.Application.Orders.Commands.PatchOrder;
using Store.Core.Application.Orders.Commands.PostOrder;
using Store.Core.Application.Orders.Commands.PutOrder;
using Store.Core.Application.Orders.Queries.GetOrderByID;
using Store.Core.Application.Orders.Queries.GetOrdersByFilter;
using Store.Resources._Bases;
using System.Threading.Tasks;

namespace Store.Resources
{
    public class OrdersController : ResourceControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<GetOrdersByFilterQueryResponse>> Get(GetOrdersByFilterQuery request)
        {
            return await Send(request);
        }

        [HttpGet("{orderid}")]
        public async Task<ActionResult<GetOrderByIDQueryResponse>> Get(GetOrderByIDQuery request)
        {
            return await Send(request);
        }
        [HttpPost]
        public async Task<ActionResult<PostOrderCommandResponse>> Post(PostOrderCommand request)
        {
            return await Send(request);
        }

        [HttpPut("{orderid}")]
        public async Task<ActionResult<PutOrderCommandResponse>> Put(PutOrderCommand request)
        {
            return await Send(request);
        }

        [HttpPatch("{orderid}")]
        public async Task<ActionResult<PatchOrderCommandResponse>> Patch(PatchOrderCommand request)
        {
            return await Send(request);
        }

        [HttpDelete("{orderid}")]
        public async Task<ActionResult<DeleteOrderCommandResponse>> Delete(DeleteOrderCommand request)
        {
            return await Send(request);
        }
    }
}