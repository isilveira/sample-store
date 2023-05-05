using BAYSOFT.Abstractions.Core.Application;
using BAYSOFT.Abstractions.Crosscutting.Helpers;
using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using ModelWrapper.Extensions.FullSearch;
using Store.Core.Application.Contexts.Store.Customers.Queries.GetCustomersByFilter;
using Store.Core.Domain.Contexts.Default.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Entity;
using Store.Core.Domain.Contexts.Store.Entities.Images.Entity;
using Store.Core.Domain.Contexts.Store.Entities.Images.Resources;
using Store.Core.Domain.Contexts.Store.Resources;
using Store.Core.Domain.Resources;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Application.Contexts.Store.Images.Queries.GetImagesByFilter
{
    [InheritStringLocalizer(typeof(EntitiesImages), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class GetImagesByFilterQueryHandler : ApplicationRequestHandler<Image, GetImagesByFilterQuery, GetImagesByFilterQueryResponse>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        private IDefaultDbContextReader Reader { get; set; }
        public GetImagesByFilterQueryHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<GetImagesByFilterQueryHandler> localizer,
            IDefaultDbContextReader reader
        )
        {
            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
            Reader = reader;
        }
        public override async Task<GetImagesByFilterQueryResponse> Handle(GetImagesByFilterQuery request, CancellationToken cancellationToken)
        {
            try
            {
                long resultCount = 0;

                var data = await Reader
                    .Query<Image>()
                    .FullSearch(request, out resultCount)
                    .ToListAsync(cancellationToken);

                return new GetImagesByFilterQueryResponse(request, data, Localizer["Successful operation!"], resultCount);
            }
            catch (Exception exception)
            {
                Logger.CreateLogger<GetImagesByFilterQueryHandler>().Log(LogLevel.Error, exception, exception.Message);

                return new GetImagesByFilterQueryResponse(ExceptionResponseHelper.CreateTuple(Localizer, request, exception));
            }
        }
    }
}
