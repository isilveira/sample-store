using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Store.Core.Domain.Contexts.Store.Entities.Images.Resources;
using Store.Core.Domain.Contexts.Store.Resources;
using Store.Core.Domain.Resources;

namespace Store.Core.Application.Contexts.Store.Images.Notifications.DeleteImage
{
    [InheritStringLocalizer(typeof(EntitiesImages), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class DeleteImageNotificationHandler : NotificationHandler<DeleteImageNotification>, INotificationHandler<DeleteImageNotification>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        public DeleteImageNotificationHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<DeleteImageNotificationHandler> localizer
        )
        {
            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
        }

        protected override void Handle(DeleteImageNotification notification)
        {
            Logger.CreateLogger<DeleteImageNotificationHandler>().Log(LogLevel.Information, $"{nameof(DeleteImageNotification)} - Event Created At: {notification.CreatedAt:yyyy-MM-dd HH:mm:ss} Payload: {JsonConvert.SerializeObject(notification.Payload)}");
        }
    }
}
