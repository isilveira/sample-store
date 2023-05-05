using BAYSOFT.Abstractions.Core.Application;
using BAYSOFT.Abstractions.Core.Domain.Exceptions;
using BAYSOFT.Abstractions.Crosscutting.Helpers;
using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using ModelWrapper.Extensions.Patch;
using Store.Core.Application.Contexts.Store.Categories.Notifications.PatchCategory;
using Store.Core.Domain.Contexts.Default.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Entity;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Resources;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Services.UpdateCategory;
using Store.Core.Domain.Contexts.Store.Resources;
using Store.Core.Domain.Resources;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Application.Contexts.Store.Categories.Commands.PatchCategory
{
    [InheritStringLocalizer(typeof(EntitiesCategories), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class PatchCategoryCommandHandler : ApplicationRequestHandler<Category, PatchCategoryCommand, PatchCategoryCommandResponse>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        private IDefaultDbContextWriter Writer { get; set; }
        public PatchCategoryCommandHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<PatchCategoryCommandHandler> localizer,
            IDefaultDbContextWriter writer
        )
        {
            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
            Writer = writer;
        }
        public override async Task<PatchCategoryCommandResponse> Handle(PatchCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.IsValid(Localizer, true);

                long resultCount = 1;

                var id = request.Project(x => x.Id);

                var data = await Writer
                    .Query<Category>()
                    .SingleOrDefaultAsync(x => x.Id == id);

                if (data == null)
                {
                    throw new EntityNotFoundException<Category>(Localizer);
                }

                request.Patch(data);

                await Mediator.Send(new UpdateCategoryServiceRequest(data));

                await Writer.CommitAsync(cancellationToken);

                await Mediator.Publish(new PatchCategoryNotification(data));

                return new PatchCategoryCommandResponse(request, data, Localizer["Successful operation!"], resultCount);
            }
            catch (Exception exception)
            {
                Logger.CreateLogger<PatchCategoryCommandHandler>().Log(LogLevel.Error, exception, exception.Message);

                return new PatchCategoryCommandResponse(ExceptionResponseHelper.CreateTuple(Localizer, request, exception));
            }
        }
    }
}
