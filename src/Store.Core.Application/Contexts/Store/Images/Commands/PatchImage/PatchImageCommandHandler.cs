using BAYSOFT.Abstractions.Core.Application;
using BAYSOFT.Abstractions.Core.Domain.Exceptions;
using BAYSOFT.Abstractions.Crosscutting.Helpers;
using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using ModelWrapper.Extensions.Patch;
using Store.Core.Application.Contexts.Store.Images.Notifications.PatchImage;
using Store.Core.Domain.Contexts.Default.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Contexts.Store.Entities.Images.Entity;
using Store.Core.Domain.Contexts.Store.Entities.Images.Resources;
using Store.Core.Domain.Contexts.Store.Entities.Images.Services.UpdateImage;
using Store.Core.Domain.Contexts.Store.Resources;
using Store.Core.Domain.Resources;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Application.Contexts.Store.Images.Commands.PatchImage
{
    [InheritStringLocalizer(typeof(EntitiesImages), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class PatchImageCommandHandler : ApplicationRequestHandler<Image, PatchImageCommand, PatchImageCommandResponse>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        private IDefaultDbContextWriter Writer { get; set; }
        public PatchImageCommandHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<PatchImageCommandHandler> localizer,
            IDefaultDbContextWriter writer
        )
        {
            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
            Writer = writer;
        }
        public override async Task<PatchImageCommandResponse> Handle(PatchImageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.IsValid(Localizer, true);

                long resultCount = 1;

                var id = request.Project(x => x.Id);

                var data = await Writer
                    .Query<Image>()
                    .SingleOrDefaultAsync(x => x.Id == id);

                if (data == null)
                {
                    throw new EntityNotFoundException<Image>(Localizer);
                }

                request.Patch(data);

                await Mediator.Send(new UpdateImageServiceRequest(data));

                await Writer.CommitAsync(cancellationToken);

                await Mediator.Publish(new PatchImageNotification(data));

                return new PatchImageCommandResponse(request, data, Localizer["Successful operation!"], resultCount);
            }
            catch (Exception exception)
            {
                Logger.CreateLogger<PatchImageCommandHandler>().Log(LogLevel.Error, exception, exception.Message);

                return new PatchImageCommandResponse(ExceptionResponseHelper.CreateTuple(Localizer, request, exception));
            }
        }
    }
}
