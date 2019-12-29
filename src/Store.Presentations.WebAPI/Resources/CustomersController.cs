using Microsoft.AspNetCore.Mvc;
using Store.Core.Application.Customers.Commands.DeleteCustomer;
using Store.Core.Application.Customers.Commands.PatchCustomer;
using Store.Core.Application.Customers.Commands.PostCustomer;
using Store.Core.Application.Customers.Commands.PutCustomer;
using Store.Core.Application.Customers.Queries.GetCustomerByID;
using Store.Core.Application.Customers.Queries.GetCustomersByFilter;
using Store.Resources._Bases;
using System.Threading.Tasks;

namespace Store.Resources
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