using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Resources;
using Store.Core.Domain.Contexts.Default.Resources;
using Store.Core.Domain.Resources;

namespace Store.Core.Application.Contexts.Default.Samples.Notifications.PatchSample
{
    [InheritStringLocalizer(typeof(EntitiesSamples), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesDefault), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class PatchSampleNotificationHandler : NotificationHandler<PatchSampleNotification>, INotificationHandler<PatchSampleNotification>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        public PatchSampleNotificationHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<PatchSampleNotificationHandler> localizer
        )
        {
            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
        }

        protected override void Handle(PatchSampleNotification notification)
        {
            Logger.CreateLogger<PatchSampleNotificationHandler>().Log(LogLevel.Information, $"{nameof(PatchSampleNotification)} - Event Created At: {notification.CreatedAt:yyyy-MM-dd HH:mm:ss} Payload: {JsonConvert.SerializeObject(notification.Payload)}");
        }
    }
}
