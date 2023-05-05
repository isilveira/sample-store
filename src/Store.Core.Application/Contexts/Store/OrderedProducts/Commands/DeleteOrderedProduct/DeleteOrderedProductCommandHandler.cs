using BAYSOFT.Abstractions.Core.Application;
using BAYSOFT.Abstractions.Core.Domain.Exceptions;
using BAYSOFT.Abstractions.Crosscutting.Helpers;
using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Store.Core.Application.Contexts.Store.OrderedProducts.Notifications.DeleteOrderedProduct;
using Store.Core.Domain.Contexts.Default.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Entity;
using Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Resources;
using Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Services.DeleteOrderedProduct;
using Store.Core.Domain.Contexts.Store.Resources;
using Store.Core.Domain.Resources;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Application.Contexts.Store.OrderedProducts.Commands.DeleteOrderedProduct
{
    [InheritStringLocalizer(typeof(EntitiesOrderedProducts), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class DeleteOrderedProductCommandHandler : ApplicationRequestHandler<OrderedProduct, DeleteOrderedProductCommand, DeleteOrderedProductCommandResponse>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        private IDefaultDbContextWriter Writer { get; set; }
        public DeleteOrderedProductCommandHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<DeleteOrderedProductCommandHandler> localizer,
            IDefaultDbContextWriter writer
        )
        {
            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
            Writer = writer;
        }
        public override async Task<DeleteOrderedProductCommandResponse> Handle(DeleteOrderedProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.IsValid(Localizer, true);

                var id = request.Project(x => x.Id);

                var data = await Writer
                    .Query<OrderedProduct>()
                    .SingleOrDefaultAsync(x => x.Id == id);

                if (data == null)
                {
                    throw new EntityNotFoundException<OrderedProduct>(Localizer);
                }

                await Mediator.Send(new DeleteOrderedProductServiceRequest(data));

                await Writer.CommitAsync(cancellationToken);

                await Mediator.Publish(new DeleteOrderedProductNotification(data));

                return new DeleteOrderedProductCommandResponse(request, data, Localizer["Successful operation!"]);
            }
            catch (Exception exception)
            {
                Logger.CreateLogger<DeleteOrderedProductCommandHandler>().Log(LogLevel.Error, exception, exception.Message);

                return new DeleteOrderedProductCommandResponse(ExceptionResponseHelper.CreateTuple(Localizer, request, exception));
            }
        }
    }
}
