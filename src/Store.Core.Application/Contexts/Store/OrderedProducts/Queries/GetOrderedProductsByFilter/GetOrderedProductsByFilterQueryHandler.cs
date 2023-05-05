using BAYSOFT.Abstractions.Core.Application;
using BAYSOFT.Abstractions.Crosscutting.Helpers;
using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using ModelWrapper.Extensions.FullSearch;
using Store.Core.Application.Contexts.Store.Images.Queries.GetImagesByFilter;
using Store.Core.Domain.Contexts.Default.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Entity;
using Store.Core.Domain.Contexts.Store.Entities.OrderedProducts.Resources;
using Store.Core.Domain.Contexts.Store.Resources;
using Store.Core.Domain.Resources;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Application.Contexts.Store.OrderedProducts.Queries.GetOrderedProductsByFilter
{
    [InheritStringLocalizer(typeof(EntitiesOrderedProducts), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class GetOrderedProductsByFilterQueryHandler : ApplicationRequestHandler<OrderedProduct, GetOrderedProductsByFilterQuery, GetOrderedProductsByFilterQueryResponse>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        private IDefaultDbContextReader Reader { get; set; }
        public GetOrderedProductsByFilterQueryHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<GetOrderedProductsByFilterQueryHandler> localizer,
            IDefaultDbContextReader reader
        )
        {
            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
            Reader = reader;
        }
        public override async Task<GetOrderedProductsByFilterQueryResponse> Handle(GetOrderedProductsByFilterQuery request, CancellationToken cancellationToken)
        {
            try
            {
                long resultCount = 0;

                var data = await Reader
                    .Query<OrderedProduct>()
                    .FullSearch(request, out resultCount)
                    .ToListAsync(cancellationToken);

                return new GetOrderedProductsByFilterQueryResponse(request, data, Localizer["Successful operation!"], resultCount);
            }
            catch (Exception exception)
            {
                Logger.CreateLogger<GetOrderedProductsByFilterQueryHandler>().Log(LogLevel.Error, exception, exception.Message);

                return new GetOrderedProductsByFilterQueryResponse(ExceptionResponseHelper.CreateTuple(Localizer, request, exception));
            }
        }
    }
}
