using BAYSOFT.Abstractions.Core.Application;
using BAYSOFT.Abstractions.Crosscutting.Helpers;
using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using ModelWrapper.Extensions.Post;
using Store.Core.Application.Contexts.Store.Categories.Notifications.PostCategory;
using Store.Core.Domain.Contexts.Default.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Entity;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Resources;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Services.CreateCategory;
using Store.Core.Domain.Contexts.Store.Resources;
using Store.Core.Domain.Resources;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Application.Contexts.Store.Categories.Commands.PostCategory
{
    [InheritStringLocalizer(typeof(EntitiesCategories), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class PostCategoryCommandHandler : ApplicationRequestHandler<Category, PostCategoryCommand, PostCategoryCommandResponse>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        private IDefaultDbContextWriter Writer { get; set; }
        public PostCategoryCommandHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<PostCategoryCommandHandler> localizer,
            IDefaultDbContextWriter writer
        )
        {
            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
            Writer = writer;
        }
        public override async Task<PostCategoryCommandResponse> Handle(PostCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.IsValid(Localizer, true);

                long resultCount = 1;

                var data = request.Post();

                await Mediator.Send(new CreateCategoryServiceRequest(data));

                await Writer.CommitAsync(cancellationToken);

                await Mediator.Publish(new PostCategoryNotification(data));

                return new PostCategoryCommandResponse(request, data, Localizer["Successful operation!"], resultCount);
            }
            catch (Exception exception)
            {
                Logger.CreateLogger<PostCategoryCommandHandler>().Log(LogLevel.Error, exception, exception.Message);

                return new PostCategoryCommandResponse(ExceptionResponseHelper.CreateTuple(Localizer, request, exception));
            }
        }
    }
}