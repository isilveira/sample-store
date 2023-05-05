using BAYSOFT.Abstractions.Core.Application;
using BAYSOFT.Abstractions.Core.Domain.Exceptions;
using BAYSOFT.Abstractions.Crosscutting.Helpers;
using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Store.Core.Application.Contexts.Store.Customers.Notifications.DeleteCustomer;
using Store.Core.Domain.Contexts.Default.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Entity;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Resources;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Services.DeleteCustomer;
using Store.Core.Domain.Contexts.Store.Resources;
using Store.Core.Domain.Resources;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Application.Contexts.Store.Customers.Commands.DeleteCustomer
{
    [InheritStringLocalizer(typeof(EntitiesCustomers), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class DeleteCustomerCommandHandler : ApplicationRequestHandler<Customer, DeleteCustomerCommand, DeleteCustomerCommandResponse>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        private IDefaultDbContextWriter Writer { get; set; }
        public DeleteCustomerCommandHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<DeleteCustomerCommandHandler> localizer,
            IDefaultDbContextWriter writer
        )
        {
            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
            Writer = writer;
        }
        public override async Task<DeleteCustomerCommandResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.IsValid(Localizer, true);

                var id = request.Project(x => x.Id);

                var data = await Writer
                    .Query<Customer>()
                    .SingleOrDefaultAsync(x => x.Id == id);

                if (data == null)
                {
                    throw new EntityNotFoundException<Customer>(Localizer);
                }

                await Mediator.Send(new DeleteCustomerServiceRequest(data));

                await Writer.CommitAsync(cancellationToken);

                await Mediator.Publish(new DeleteCustomerNotification(data));

                return new DeleteCustomerCommandResponse(request, data, Localizer["Successful operation!"]);
            }
            catch (Exception exception)
            {
                Logger.CreateLogger<DeleteCustomerCommandHandler>().Log(LogLevel.Error, exception, exception.Message);

                return new DeleteCustomerCommandResponse(ExceptionResponseHelper.CreateTuple(Localizer, request, exception));
            }
        }
    }
}
