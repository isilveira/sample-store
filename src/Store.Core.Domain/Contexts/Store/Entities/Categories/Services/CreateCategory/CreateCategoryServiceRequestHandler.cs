﻿using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using Microsoft.Extensions.Localization;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Entity;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Resources;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Validations.DomainValidations;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Validations.EntityValidations;
using Store.Core.Domain.Contexts.Store.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Contexts.Store.Resources;
using Store.Core.Domain.Resources;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Domain.Contexts.Store.Entities.Categories.Services.CreateCategory
{
    [InheritStringLocalizer(typeof(EntitiesCategories), Priority = 0)]
    [InheritStringLocalizer(typeof(EntitiesStore), Priority = 1)]
    [InheritStringLocalizer(typeof(Messages), Priority = 2)]
    public class CreateCategoryServiceRequestHandler
        : DomainServiceRequestHandler<Category, CreateCategoryServiceRequest>
    {
        private IStoreDbContextWriter Writer { get; set; }
        public CreateCategoryServiceRequestHandler(
            IStoreDbContextWriter writer,
            IStringLocalizer<CreateCategoryServiceRequestHandler> localizer,
            CategoryValidator entityValidator,
            CreateCategorySpecificationsValidator domainValidator
        ) : base(localizer, entityValidator, domainValidator)
        {
            Writer = writer;
        }

        public override async Task<Category> Handle(CreateCategoryServiceRequest request, CancellationToken cancellationToken)
        {
            ValidateEntity(request.Payload);

            ValidateDomain(request.Payload);

            await Writer.AddAsync(request.Payload);

            return request.Payload;
        }
    }
}
