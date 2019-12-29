using Microsoft.AspNetCore.Mvc;
using Store.Core.Application.OrderedProducts.Commands.DeleteOrderedProduct;
using Store.Core.Application.OrderedProducts.Commands.PatchOrderedProduct;
using Store.Core.Application.OrderedProducts.Commands.PostOrderedProduct;
using Store.Core.Application.OrderedProducts.Commands.PutOrderedProduct;
using Store.Core.Application.OrderedProducts.Queries.GetOrderedProductByID;
using Store.Core.Application.OrderedProducts.Queries.GetOrderedProductsByFilter;
using Store.Resources._Bases;
using System.Threading.Tasks;

namespace Store.Resources
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