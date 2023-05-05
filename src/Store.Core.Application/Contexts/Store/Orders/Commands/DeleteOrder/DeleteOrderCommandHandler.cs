using BAYSOFT.Abstractions.Core.Application;
using BAYSOFT.Abstractions.Core.Domain.Exceptions;
using BAYSOFT.Abstractions.Crosscutting.Helpers;
using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Store.Core.Application.Contexts.Store.Orders.Notifications.DeleteOrder;
using Store.Core.Domain.Contexts.Default.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Entity;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Resources;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Services.DeleteOrder;
using Store.Core.Domain.Contexts.Store.Resources;
using Store.Core.Domain.Resources;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Application.Contexts.Store.Orders.Commands.DeleteOrder
{
    [InheritStringLocalizer(typeof(EntitiesOrders), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class DeleteOrderCommandHandler : ApplicationRequestHandler<Order, DeleteOrderCommand, DeleteOrderCommandResponse>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        private IDefaultDbContextWriter Writer { get; set; }
        public DeleteOrderCommandHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<DeleteOrderCommandHandler> localizer,
            IDefaultDbContextWriter writer
        )
        {
            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
            Writer = writer;
        }
        public override async Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.IsValid(Localizer, true);

                var id = request.Project(x => x.Id);

                var data = await Writer
                    .Query<Order>()
                    .SingleOrDefaultAsync(x => x.Id == id);

                if (data == null)
                {
                    throw new EntityNotFoundException<Order>(Localizer);
                }

                await Mediator.Send(new DeleteOrderServiceRequest(data));

                await Writer.CommitAsync(cancellationToken);

                await Mediator.Publish(new DeleteOrderNotification(data));

                return new DeleteOrderCommandResponse(request, data, Localizer["Successful operation!"]);
            }
            catch (Exception exception)
            {
                Logger.CreateLogger<DeleteOrderCommandHandler>().Log(LogLevel.Error, exception, exception.Message);

                return new DeleteOrderCommandResponse(ExceptionResponseHelper.CreateTuple(Localizer, request, exception));
            }
        }
    }
}
