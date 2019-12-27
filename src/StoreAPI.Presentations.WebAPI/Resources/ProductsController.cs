﻿using Microsoft.AspNetCore.Mvc;
using StoreAPI.Core.Application.Products.Commands.DeleteProduct;
using StoreAPI.Core.Application.Products.Commands.PatchProduct;
using StoreAPI.Core.Application.Products.Commands.PostProduct;
using StoreAPI.Core.Application.Products.Commands.PutProduct;
using StoreAPI.Core.Application.Products.Queries.GetProductByID;
using StoreAPI.Core.Application.Products.Queries.GetProductsByFilter;
using StoreAPI.Resources._Bases;
using System.Threading.Tasks;

namespace StoreAPI.Resources
{
    public class ProductsController : ResourceControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<GetProductsByFilterQueryResponse>> Get(GetProductsByFilterQuery request)
        {
            return await Send(request);
        }

        [HttpGet("{productid}")]
        public async Task<ActionResult<GetProductByIDQueryResponse>> Get(GetProductByIDQuery request)
        {
            return await Send(request);
        }
        [HttpPost]
        public async Task<ActionResult<PostProductCommandResponse>> Post(PostProductCommand request)
        {
            return await Send(request);
        }

        [HttpPut("{productid}")]
        public async Task<ActionResult<PutProductCommandResponse>> Put(PutProductCommand request)
        {
            return await Send(request);
        }

        [HttpPatch("{productid}")]
        public async Task<ActionResult<PatchProductCommandResponse>> Patch(PatchProductCommand request)
        {
            return await Send(request);
        }

        [HttpDelete("{productid}")]
        public async Task<ActionResult<DeleteProductCommandResponse>> Delete(DeleteProductCommand request)
        {
            return await Send(request);
        }
    }
}
