using BAYSOFT.Abstractions.Core.Application;
using BAYSOFT.Abstractions.Core.Domain.Exceptions;
using BAYSOFT.Abstractions.Crosscutting.Helpers;
using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using ModelWrapper.Extensions.Patch;
using Store.Core.Application.Contexts.Store.Customers.Notifications.PatchCustomer;
using Store.Core.Domain.Contexts.Default.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Entity;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Resources;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Services.UpdateCustomer;
using Store.Core.Domain.Contexts.Store.Resources;
using Store.Core.Domain.Resources;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Application.Contexts.Store.Customers.Commands.PatchCustomer
{
    [InheritStringLocalizer(typeof(EntitiesCustomers), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class PatchCustomerCommandHandler : ApplicationRequestHandler<Customer, PatchCustomerCommand, PatchCustomerCommandResponse>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        private IDefaultDbContextWriter Writer { get; set; }
        public PatchCustomerCommandHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<PatchCustomerCommandHandler> localizer,
            IDefaultDbContextWriter writer
        )
        {
            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
            Writer = writer;
        }
        public override async Task<PatchCustomerCommandResponse> Handle(PatchCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.IsValid(Localizer, true);

                long resultCount = 1;

                var id = request.Project(x => x.Id);

                var data = await Writer
                    .Query<Customer>()
                    .SingleOrDefaultAsync(x => x.Id == id);

                if (data == null)
                {
                    throw new EntityNotFoundException<Customer>(Localizer);
                }

                request.Patch(data);

                await Mediator.Send(new UpdateCustomerServiceRequest(data));

                await Writer.CommitAsync(cancellationToken);

                await Mediator.Publish(new PatchCustomerNotification(data));

                return new PatchCustomerCommandResponse(request, data, Localizer["Successful operation!"], resultCount);
            }
            catch (Exception exception)
            {
                Logger.CreateLogger<PatchCustomerCommandHandler>().Log(LogLevel.Error, exception, exception.Message);

                return new PatchCustomerCommandResponse(ExceptionResponseHelper.CreateTuple(Localizer, request, exception));
            }
        }
    }
}
