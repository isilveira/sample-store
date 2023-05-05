using BAYSOFT.Abstractions.Core.Application;
using BAYSOFT.Abstractions.Core.Domain.Exceptions;
using BAYSOFT.Abstractions.Crosscutting.Helpers;
using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using ModelWrapper.Extensions.Select;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Entity;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Resources;
using Store.Core.Domain.Contexts.Store.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Contexts.Store.Resources;
using Store.Core.Domain.Resources;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Application.Contexts.Store.Orders.Queries.GetOrderById
{
    [InheritStringLocalizer(typeof(EntitiesOrders), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class GetOrderByIdQueryHandler : ApplicationRequestHandler<Order, GetOrderByIdQuery, GetOrderByIdQueryResponse>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        private IStoreDbContextReader Reader { get; set; }
        public GetOrderByIdQueryHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<GetOrderByIdQueryHandler> localizer,
            IStoreDbContextReader reader
        )
        {
            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
            Reader = reader;
        }
        public override async Task<GetOrderByIdQueryResponse> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                long resultCount = 1;

                var id = request.Project(x => x.Id);

                var data = await Reader
                    .Query<Order>()
                    .Where(x => x.Id == id)
                    .Select(request)
                    .SingleOrDefaultAsync();

                if (data == null)
                {
                    throw new EntityNotFoundException<Order>(Localizer);
                }

                return new GetOrderByIdQueryResponse(request, data, Localizer["Successful operation!"], resultCount);
            }
            catch (Exception exception)
            {
                Logger.CreateLogger<GetOrderByIdQueryHandler>().Log(LogLevel.Error, exception, exception.Message);

                return new GetOrderByIdQueryResponse(ExceptionResponseHelper.CreateTuple(Localizer, request, exception));
            }
        }
    }
}
