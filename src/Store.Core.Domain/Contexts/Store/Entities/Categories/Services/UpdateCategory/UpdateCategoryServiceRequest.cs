using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.Categories.Services.UpdateCategory
{
    public class UpdateCategoryServiceRequest : DomainServiceRequest<Category>
    {
        public UpdateCategoryServiceRequest(Category payload) : base(payload)
        {
        }
    }
}
