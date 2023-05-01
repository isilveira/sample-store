using FluentValidation;
using MediatR;
using NetDevPack.Specification;
using Store.Core.Domain.Entities.Default;
using Store.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using Store.Core.Domain.Interfaces.Services.Default.Categories;
using Store.Core.Domain.Validations.DomainValidations.Default.Categories;
using Store.Core.Domain.Validations.EntityValidations.Default;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.Domain.Services.Default.Categories
{
    public class PostCategoryService : DomainService<Category>, IPostCategoryService
    {
        private IDefaultDbContext Context { get; set; }
        public PostCategoryService(
            IDefaultDbContext context,
            CategoryValidator entityValidator,
            PostCategorySpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }
        public override async Task Run(Category entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            await Context.Categories.AddAsync(entity);
        }
    }

    public class CreateCategoryServiceRequest: IRequest<Category>
    {
        public Category Payload { get; set; }
        public CreateCategoryServiceRequest(Category payload)
        {
            Payload = payload;
        }
    }
    public class CreateCategoryServiceRequestHandler : DomainService<Category>, IPostCategoryService, IRequestHandler<CreateCategoryServiceRequest, Category>
    {
        private IDefaultDbContext Context { get; set; }
        public CreateCategoryServiceRequestHandler(
            IDefaultDbContext context,
            CategoryValidator entityValidator,
            PostCategorySpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }

        public async Task<Category> Handle(CreateCategoryServiceRequest request, CancellationToken cancellationToken)
        {
            await Run(request.Payload);

            return request.Payload;
        }
        public override async Task Run(Category entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            await Context.Categories.AddAsync(entity);
        }
    }
}
