using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Resources;
using Store.Core.Domain.Contexts.Default.Resources;
using Store.Core.Domain.Resources;

namespace Store.Core.Application.Contexts.Default.Samples.Notifications.PutSample
{
    [InheritStringLocalizer(typeof(EntitiesSamples), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesDefault), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class PutSampleNotificationHandler : NotificationHandler<PutSampleNotification>, INotificationHandler<PutSampleNotification>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        public PutSampleNotificationHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<PutSampleNotificationHandler> localizer
        )
        {
            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
        }

        protected override void Handle(PutSampleNotification notification)
        {
            Logger.CreateLogger<PutSampleNotificationHandler>().Log(LogLevel.Information, $"{nameof(PutSampleNotification)} - Event Created At: {notification.CreatedAt:yyyy-MM-dd HH:mm:ss} Payload: {JsonConvert.SerializeObject(notification.Payload)}");
        }
    }
}
