using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Core.Application.Products.Commands.DeleteProduct;
using StoreAPI.Core.Application.Products.Commands.PostProduct;
using StoreAPI.Core.Application.Products.Queries.GetProductByID;
using StoreAPI.Core.Application.Products.Queries.GetProductsByFilter;
using StoreAPI.Resources._Bases;
using System;
using System.Threading.Tasks;

namespace StoreAPI.Resources
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ResourceControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<GetProductsByFilterQueryResponse>> Get([FromQuery]GetProductsByFilterQuery request)
        {
            return await Send(request);
        }

        [HttpGet("{productid}")]
        public async Task<ActionResult<GetProductByIDQueryResponse>> Get([FromRoute] GetProductByIDQuery request)
        {
            return await Send(request);
        }
        [HttpPost]
        public async Task<ActionResult<PostProductCommandResponse>> Post([FromBody] PostProductCommand request)
        {
            return await Send(request);
        }

        [HttpPut("{productid}")]
        public void Put(int productid, [FromBody] string value)
        {

        }

        [HttpPatch("{productid}")]
        public void Patch(int productid, [FromBody] string value)
        {

        }

        [HttpDelete("{productid}")]
        public async Task<ActionResult<DeleteProductCommandResponse>> Delete([FromRoute]DeleteProductCommand request)
        {
            return await Send(request);
        }
    }
}
