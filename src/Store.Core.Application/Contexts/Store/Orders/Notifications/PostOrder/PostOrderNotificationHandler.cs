using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Resources;
using Store.Core.Domain.Contexts.Store.Resources;
using Store.Core.Domain.Resources;

namespace Store.Core.Application.Contexts.Store.Orders.Notifications.PostOrder
{
    [InheritStringLocalizer(typeof(EntitiesOrders), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class PostOrderNotificationHandler : NotificationHandler<PostOrderNotification>, INotificationHandler<PostOrderNotification>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        public PostOrderNotificationHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<PostOrderNotificationHandler> localizer
        )
        {
            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
        }

        protected override void Handle(PostOrderNotification notification)
        {
            Logger.CreateLogger<PostOrderNotificationHandler>().Log(LogLevel.Information, $"{nameof(PostOrderNotification)} - Event Created At: {notification.CreatedAt:yyyy-MM-dd HH:mm:ss} Payload: {JsonConvert.SerializeObject(notification.Payload)}");
        }
    }
}
