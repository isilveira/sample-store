using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Store.Core.Domain.Contexts.Store.Entities.Products.Resources;
using Store.Core.Domain.Contexts.Store.Resources;
using Store.Core.Domain.Resources;

namespace Store.Core.Application.Contexts.Store.Products.Notifications.PatchProduct
{
    [InheritStringLocalizer(typeof(EntitiesProducts), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class PatchProductNotificationHandler : NotificationHandler<PatchProductNotification>, INotificationHandler<PatchProductNotification>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        public PatchProductNotificationHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<PatchProductNotificationHandler> localizer
        )
        {
            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
        }

        protected override void Handle(PatchProductNotification notification)
        {
            Logger.CreateLogger<PatchProductNotificationHandler>().Log(LogLevel.Information, $"{nameof(PatchProductNotification)} - Event Created At: {notification.CreatedAt:yyyy-MM-dd HH:mm:ss} Payload: {JsonConvert.SerializeObject(notification.Payload)}");
        }
    }
}
