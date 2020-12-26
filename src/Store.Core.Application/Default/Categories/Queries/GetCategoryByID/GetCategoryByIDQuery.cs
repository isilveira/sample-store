using Store.Core.Domain.Entities.Default;

namespace Store.Core.Application.Default.Categories.Queries.GetCategoryByID
{
    public class GetCategoryByIDQuery : ApplicationRequest<Category, GetCategoryByIDQueryResponse>
    {
        public GetCategoryByIDQuery()
        {
            ConfigKeys(x => x.Id);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
