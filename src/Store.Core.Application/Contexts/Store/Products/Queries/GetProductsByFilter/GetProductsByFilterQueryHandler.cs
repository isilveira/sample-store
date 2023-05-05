using BAYSOFT.Abstractions.Core.Application;
using BAYSOFT.Abstractions.Crosscutting.Helpers;
using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using ModelWrapper.Extensions.FullSearch;
using Store.Core.Application.Contexts.Store.Orders.Queries.GetOrdersByFilter;
using Store.Core.Domain.Contexts.Default.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Contexts.Store.Entities.Orders.Entity;
using Store.Core.Domain.Contexts.Store.Entities.Products.Entity;
using Store.Core.Domain.Contexts.Store.Entities.Products.Resources;
using Store.Core.Domain.Contexts.Store.Resources;
using Store.Core.Domain.Resources;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Application.Contexts.Store.Products.Queries.GetProductsByFilter
{
    [InheritStringLocalizer(typeof(EntitiesProducts), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class GetProductsByFilterQueryHandler : ApplicationRequestHandler<Product, GetProductsByFilterQuery, GetProductsByFilterQueryResponse>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        private IDefaultDbContextReader Reader { get; set; }
        public GetProductsByFilterQueryHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<GetProductsByFilterQueryHandler> localizer,
            IDefaultDbContextReader reader
        )
        {
            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
            Reader = reader;
        }
        public override async Task<GetProductsByFilterQueryResponse> Handle(GetProductsByFilterQuery request, CancellationToken cancellationToken)
        {
            try
            {
                long resultCount = 0;

                var data = await Reader
                    .Query<Product>()
                    .FullSearch(request, out resultCount)
                    .ToListAsync(cancellationToken);

                return new GetProductsByFilterQueryResponse(request, data, Localizer["Successful operation!"], resultCount);
            }
            catch (Exception exception)
            {
                Logger.CreateLogger<GetProductsByFilterQueryHandler>().Log(LogLevel.Error, exception, exception.Message);

                return new GetProductsByFilterQueryResponse(ExceptionResponseHelper.CreateTuple(Localizer, request, exception));
            }
        }
    }
}
