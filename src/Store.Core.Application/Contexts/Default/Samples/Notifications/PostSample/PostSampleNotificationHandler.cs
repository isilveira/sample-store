using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Resources;
using Store.Core.Domain.Contexts.Default.Resources;
using Store.Core.Domain.Resources;

namespace Store.Core.Application.Contexts.Default.Samples.Notifications.PostSample
{
    [InheritStringLocalizer(typeof(EntitiesSamples), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesDefault), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class PostSampleNotificationHandler : NotificationHandler<PostSampleNotification>, INotificationHandler<PostSampleNotification>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        public PostSampleNotificationHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<PostSampleNotificationHandler> localizer
        )
        {
            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
        }

        protected override void Handle(PostSampleNotification notification)
        {
            Logger.CreateLogger<PostSampleNotificationHandler>().Log(LogLevel.Information, $"{nameof(PostSampleNotification)} - Event Created At: {notification.CreatedAt:yyyy-MM-dd HH:mm:ss} Payload: {JsonConvert.SerializeObject(notification.Payload)}");
        }
    }
}
