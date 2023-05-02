using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.Categories.Services.CreateCategory
{
    public class CreateCategoryServiceRequest : DomainServiceRequest<Category>
    {
        public CreateCategoryServiceRequest(Category payload) : base(payload)
        {
        }
    }
}
