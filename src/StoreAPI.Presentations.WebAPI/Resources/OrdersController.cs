using Microsoft.AspNetCore.Mvc;
using StoreAPI.Core.Application.Orders.Commands.DeleteOrder;
using StoreAPI.Core.Application.Orders.Commands.PatchOrder;
using StoreAPI.Core.Application.Orders.Commands.PostOrder;
using StoreAPI.Core.Application.Orders.Commands.PutOrder;
using StoreAPI.Core.Application.Orders.Queries.GetOrderByID;
using StoreAPI.Core.Application.Orders.Queries.GetOrdersByFilter;
using StoreAPI.Resources._Bases;
using System.Threading.Tasks;

namespace StoreAPI.Resources
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