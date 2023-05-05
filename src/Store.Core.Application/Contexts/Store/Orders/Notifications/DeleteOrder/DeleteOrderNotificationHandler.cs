using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Resources;
using Store.Core.Domain.Contexts.Store.Resources;
using Store.Core.Domain.Resources;

namespace Store.Core.Application.Contexts.Store.Orders.Notifications.DeleteOrder
{
    [InheritStringLocalizer(typeof(EntitiesOrders), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class DeleteOrderNotificationHandler : NotificationHandler<DeleteOrderNotification>, INotificationHandler<DeleteOrderNotification>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        public DeleteOrderNotificationHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<DeleteOrderNotification> localizer
        )
        {
            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
        }

        protected override void Handle(DeleteOrderNotification notification)
        {
            Logger.CreateLogger<DeleteOrderNotificationHandler>().Log(LogLevel.Information, $"{nameof(DeleteOrderNotification)} - Event Created At: {notification.CreatedAt:yyyy-MM-dd HH:mm:ss} Payload: {JsonConvert.SerializeObject(notification.Payload)}");
        }
    }
}
