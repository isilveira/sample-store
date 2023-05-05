using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Resources;
using Store.Core.Domain.Contexts.Store.Resources;
using Store.Core.Domain.Resources;

namespace Store.Core.Application.Contexts.Store.Categories.Notifications.PostCategory
{
    [InheritStringLocalizer(typeof(EntitiesCategories), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class PostCategoryNotificationHandler : NotificationHandler<PostCategoryNotification>, INotificationHandler<PostCategoryNotification>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        public PostCategoryNotificationHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<PostCategoryNotificationHandler> localizer
        )
        {
            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
        }

        protected override void Handle(PostCategoryNotification notification)
        {
            Logger.CreateLogger<PostCategoryNotificationHandler>().Log(LogLevel.Information, $"{nameof(PostCategoryNotification)} - Event Created At: {notification.CreatedAt:yyyy-MM-dd HH:mm:ss} Payload: {JsonConvert.SerializeObject(notification.Payload)}");
        }
    }
}
