using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Resources;
using Store.Core.Domain.Contexts.Store.Resources;
using Store.Core.Domain.Resources;

namespace Store.Core.Application.Contexts.Store.OrderedProducts.Notifications.PostOrderedProduct
{
    [InheritStringLocalizer(typeof(EntitiesOrderedProducts), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class PostOrderedProductNotificationHandler : NotificationHandler<PostOrderedProductNotification>, INotificationHandler<PostOrderedProductNotification>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        public PostOrderedProductNotificationHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<PostOrderedProductNotificationHandler> localizer
        )
        {
            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
        }

        protected override void Handle(PostOrderedProductNotification notification)
        {
            Logger.CreateLogger<PostOrderedProductNotificationHandler>().Log(LogLevel.Information, $"{nameof(PostOrderedProductNotification)} - Event Created At: {notification.CreatedAt:yyyy-MM-dd HH:mm:ss} Payload: {JsonConvert.SerializeObject(notification.Payload)}");
        }
    }
}
