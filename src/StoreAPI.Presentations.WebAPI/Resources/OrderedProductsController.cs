using Microsoft.AspNetCore.Mvc;
using StoreAPI.Core.Application.OrderedProducts.Commands.DeleteOrderedProduct;
using StoreAPI.Core.Application.OrderedProducts.Commands.PatchOrderedProduct;
using StoreAPI.Core.Application.OrderedProducts.Commands.PostOrderedProduct;
using StoreAPI.Core.Application.OrderedProducts.Commands.PutOrderedProduct;
using StoreAPI.Core.Application.OrderedProducts.Queries.GetOrderedProductByID;
using StoreAPI.Core.Application.OrderedProducts.Queries.GetOrderedProductsByFilter;
using StoreAPI.Resources._Bases;
using System.Threading.Tasks;

namespace StoreAPI.Resources
{
    public class OrderedProductsController : ResourceControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<GetOrderedProductsByFilterQueryResponse>> Get(GetOrderedProductsByFilterQuery request)
        {
            return await Send(request);
        }

        [HttpGet("{orderedproductid}")]
        public async Task<ActionResult<GetOrderedProductByIDQueryResponse>> Get(GetOrderedProductByIDQuery request)
        {
            return await Send(request);
        }
        [HttpPost]
        public async Task<ActionResult<PostOrderedProductCommandResponse>> Post(PostOrderedProductCommand request)
        {
            return await Send(request);
        }

        [HttpPut("{orderedproductid}")]
        public async Task<ActionResult<PutOrderedProductCommandResponse>> Put(PutOrderedProductCommand request)
        {
            return await Send(request);
        }

        [HttpPatch("{orderedproductid}")]
        public async Task<ActionResult<PatchOrderedProductCommandResponse>> Patch(PatchOrderedProductCommand request)
        {
            return await Send(request);
        }

        [HttpDelete("{orderedproductid}")]
        public async Task<ActionResult<DeleteOrderedProductCommandResponse>> Delete(DeleteOrderedProductCommand request)
        {
            return await Send(request);
        }
    }
}