using BAYSOFT.Abstractions.Core.Application;
using BAYSOFT.Abstractions.Core.Domain.Exceptions;
using BAYSOFT.Abstractions.Crosscutting.Helpers;
using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Store.Core.Application.Contexts.Default.Samples.Notifications.DeleteSample;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Entity;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Resources;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Services.DeleteSample;
using Store.Core.Domain.Contexts.Default.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Contexts.Default.Resources;
using Store.Core.Domain.Resources;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Application.Contexts.Default.Samples.Commands.DeleteSample
{
    [InheritStringLocalizer(typeof(EntitiesSamples), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesDefault), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class DeleteSampleCommandHandler : ApplicationRequestHandler<Sample, DeleteSampleCommand, DeleteSampleCommandResponse>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        private IDefaultDbContextWriter Writer { get; set; }
        public DeleteSampleCommandHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<DeleteSampleCommandHandler> localizer,
            IDefaultDbContextWriter writer
        )
        {
            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
            Writer = writer;
        }
        public override async Task<DeleteSampleCommandResponse> Handle(DeleteSampleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.IsValid(Localizer, true);

                var id = request.Project(x => x.Id);

                var data = await Writer
                    .Query<Sample>()
                    .SingleOrDefaultAsync(x => x.Id == id);

                if (data == null)
                {
                    throw new EntityNotFoundException<Sample>(Localizer);
                }

                await Mediator.Send(new DeleteSampleServiceRequest(data));

                await Writer.CommitAsync(cancellationToken);

                await Mediator.Publish(new DeleteSampleNotification(data));

                return new DeleteSampleCommandResponse(request, data, Localizer["Successful operation!"]);
            }
            catch (Exception exception)
            {
                Logger.CreateLogger<DeleteSampleCommandHandler>().Log(LogLevel.Error, exception, exception.Message);

                return new DeleteSampleCommandResponse(ExceptionResponseHelper.CreateTuple(Localizer, request, exception));
            }
        }
    }
}
