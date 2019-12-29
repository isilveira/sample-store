﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.Core.Application.Interfaces.Infrastructures.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerCommandResponse>
    {
        private IStoreContext Context { get; set; }
        public DeleteCustomerCommandHandler(IStoreContext context)
        {
            Context = context;
        }
        public async Task<DeleteCustomerCommandResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.CustomerID);

            var data = await Context.Customers.SingleOrDefaultAsync(x => x.CustomerID == id);

            if (data == null)
                throw new Exception("Customer not found!");

            Context.Customers.Remove(data);

            await Context.SaveChangesAsync();

            return new DeleteCustomerCommandResponse(request, data, "Successful operation!");
        }
    }
}
