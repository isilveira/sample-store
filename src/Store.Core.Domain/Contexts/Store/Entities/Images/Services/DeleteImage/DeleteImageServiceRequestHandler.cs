using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using Microsoft.Extensions.Localization;
using Store.Core.Domain.Contexts.Store.Entities.Images.Entity;
using Store.Core.Domain.Contexts.Store.Entities.Images.Resources;
using Store.Core.Domain.Contexts.Store.Entities.Images.Validations.DomainValidations;
using Store.Core.Domain.Contexts.Store.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Contexts.Store.Resources;
using Store.Core.Domain.Resources;
using Store.Core.Domain.Validations.EntityValidations.Default;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Domain.Contexts.Store.Entities.Images.Services.DeleteImage
{
    [InheritStringLocalizer(typeof(EntitiesImages), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class DeleteImageServiceRequestHandler
        : DomainServiceRequestHandler<Image, DeleteImageServiceRequest>
    {
        private IStoreDbContextWriter Writer { get; set; }
        public DeleteImageServiceRequestHandler(
            IStoreDbContextWriter writer,
            IStringLocalizer<DeleteImageServiceRequestHandler> localizer,
            ImageValidator entityValidator,
            DeleteImageSpecificationsValidator domainValidator
        ) : base(localizer, entityValidator, domainValidator)
        {
            Writer = writer;
        }

        public override async Task<Image> Handle(DeleteImageServiceRequest request, CancellationToken cancellationToken)
        {
            ValidateEntity(request.Payload);

            ValidateDomain(request.Payload);

            Writer.Remove(request.Payload);

            return request.Payload;
        }
    }
}
