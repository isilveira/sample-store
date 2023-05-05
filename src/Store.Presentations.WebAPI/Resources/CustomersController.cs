using Store.Presentations.WebAPI.Abstractions.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Store.Core.Application.Contexts.Store.Customers.Commands.DeleteCustomer;
using Store.Core.Application.Contexts.Store.Customers.Commands.PatchCustomer;
using Store.Core.Application.Contexts.Store.Customers.Commands.PostCustomer;
using Store.Core.Application.Contexts.Store.Customers.Commands.PutCustomer;
using Store.Core.Application.Contexts.Store.Customers.Queries.GetCustomerById;
using Store.Core.Application.Contexts.Store.Customers.Queries.GetCustomersByFilter;

namespace Store.Resources
{
    public class CustomersController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetCustomersByFilterQueryResponse>> Get(GetCustomersByFilterQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCustomerByIdQueryResponse>> Get(GetCustomerByIdQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<PostCustomerCommandResponse>> Post(PostCustomerCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PutCustomerCommandResponse>> Put(PutCustomerCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<PatchCustomerCommandResponse>> Patch(PatchCustomerCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteCustomerCommandResponse>> Delete(DeleteCustomerCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }
    }
}
