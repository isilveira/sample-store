using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using Store.Core.Domain.Contexts.Store.Entities.Categories.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.Categories.Services.DeleteCategory
{
    public class DeleteCategoryServiceRequest : DomainServiceRequest<Category>
    {
        public DeleteCategoryServiceRequest(Category payload) : base(payload)
        {
        }
    }
}
