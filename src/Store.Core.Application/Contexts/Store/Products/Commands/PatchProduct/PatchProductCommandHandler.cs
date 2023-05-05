using BAYSOFT.Abstractions.Core.Application;
using BAYSOFT.Abstractions.Core.Domain.Exceptions;
using BAYSOFT.Abstractions.Crosscutting.Helpers;
using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using ModelWrapper.Extensions.Patch;
using Store.Core.Application.Contexts.Store.Products.Notifications.PatchProduct;
using Store.Core.Domain.Contexts.Default.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Contexts.Store.Entities.Products.Entity;
using Store.Core.Domain.Contexts.Store.Entities.Products.Resources;
using Store.Core.Domain.Contexts.Store.Entities.Products.Services.UpdateProduct;
using Store.Core.Domain.Contexts.Store.Resources;
using Store.Core.Domain.Resources;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Application.Contexts.Store.Products.Commands.PatchProduct
{
    [InheritStringLocalizer(typeof(EntitiesProducts), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class PatchProductCommandHandler : ApplicationRequestHandler<Product, PatchProductCommand, PatchProductCommandResponse>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        private IDefaultDbContextWriter Writer { get; set; }
        public PatchProductCommandHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<PatchProductCommandHandler> localizer,
            IDefaultDbContextWriter writer
        )
        {
            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
            Writer = writer;
        }
        public override async Task<PatchProductCommandResponse> Handle(PatchProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.IsValid(Localizer, true);

                long resultCount = 1;

                var id = request.Project(x => x.Id);

                var data = await Writer
                    .Query<Product>()
                    .SingleOrDefaultAsync(x => x.Id == id);

                if (data == null)
                {
                    throw new EntityNotFoundException<Product>(Localizer);
                }

                request.Patch(data);

                await Mediator.Send(new UpdateProductServiceRequest(data));

                await Writer.CommitAsync(cancellationToken);

                await Mediator.Publish(new PatchProductNotification(data));

                return new PatchProductCommandResponse(request, data, Localizer["Successful operation!"], resultCount);
            }
            catch (Exception exception)
            {
                Logger.CreateLogger<PatchProductCommandHandler>().Log(LogLevel.Error, exception, exception.Message);

                return new PatchProductCommandResponse(ExceptionResponseHelper.CreateTuple(Localizer, request, exception));
            }
        }
    }
}
