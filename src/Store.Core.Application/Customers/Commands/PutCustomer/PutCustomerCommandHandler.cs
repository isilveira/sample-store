﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Put;
using Store.Core.Application.Interfaces.Infrastructures.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Application.Customers.Commands.PutCustomer
{
    public class PutCustomerCommandHandler : IRequestHandler<PutCustomerCommand, PutCustomerCommandResponse>
    {
        private IStoreContext Context { get; set; }
        public PutCustomerCommandHandler(IStoreContext context)
        {
            Context = context;
        }
        public async Task<PutCustomerCommandResponse> Handle(PutCustomerCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.CustomerID);
            var data = await Context.Customers.SingleOrDefaultAsync(x => x.CustomerID == id);

            if (data == null)
            {
                throw new Exception("Customer not found!");
            }

            request.Put(data);

            await Context.SaveChangesAsync();

            return new PutCustomerCommandResponse(request, data, "Successful operation!");
        }
    }
}
