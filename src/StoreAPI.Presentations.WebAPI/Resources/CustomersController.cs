using Microsoft.AspNetCore.Mvc;
using StoreAPI.Core.Application.Customers.Commands.DeleteCustomer;
using StoreAPI.Core.Application.Customers.Commands.PatchCustomer;
using StoreAPI.Core.Application.Customers.Commands.PostCustomer;
using StoreAPI.Core.Application.Customers.Commands.PutCustomer;
using StoreAPI.Core.Application.Customers.Queries.GetCustomerByID;
using StoreAPI.Core.Application.Customers.Queries.GetCustomersByFilter;
using StoreAPI.Resources._Bases;
using System.Threading.Tasks;

namespace StoreAPI.Resources
{
    public class CustomersController : ResourceControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<GetCustomersByFilterQueryResponse>> Get(GetCustomersByFilterQuery request)
        {
            return await Send(request);
        }

        [HttpGet("{customerid}")]
        public async Task<ActionResult<GetCustomerByIDQueryResponse>> Get(GetCustomerByIDQuery request)
        {
            return await Send(request);
        }
        [HttpPost]
        public async Task<ActionResult<PostCustomerCommandResponse>> Post(PostCustomerCommand request)
        {
            return await Send(request);
        }

        [HttpPut("{customerid}")]
        public async Task<ActionResult<PutCustomerCommandResponse>> Put(PutCustomerCommand request)
        {
            return await Send(request);
        }

        [HttpPatch("{customerid}")]
        public async Task<ActionResult<PatchCustomerCommandResponse>> Patch(PatchCustomerCommand request)
        {
            return await Send(request);
        }

        [HttpDelete("{customerid}")]
        public async Task<ActionResult<DeleteCustomerCommandResponse>> Delete(DeleteCustomerCommand request)
        {
            return await Send(request);
        }
    }
}