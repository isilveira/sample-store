using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Resources;
using Store.Core.Domain.Contexts.Store.Resources;
using Store.Core.Domain.Resources;

namespace Store.Core.Application.Contexts.Store.Customers.Notifications.DeleteCustomer
{
    [InheritStringLocalizer(typeof(EntitiesCustomers), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class DeleteCustomerNotificationHandler : NotificationHandler<DeleteCustomerNotification>, INotificationHandler<DeleteCustomerNotification>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        public DeleteCustomerNotificationHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<DeleteCustomerNotificationHandler> localizer
        )
        {
            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
        }

        protected override void Handle(DeleteCustomerNotification notification)
        {
            Logger.CreateLogger<DeleteCustomerNotificationHandler>().Log(LogLevel.Information, $"{nameof(DeleteCustomerNotification)} - Event Created At: {notification.CreatedAt:yyyy-MM-dd HH:mm:ss} Payload: {JsonConvert.SerializeObject(notification.Payload)}");
        }
    }
}
