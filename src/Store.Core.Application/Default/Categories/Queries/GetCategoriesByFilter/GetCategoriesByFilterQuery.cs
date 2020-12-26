using Store.Core.Domain.Entities.Default;

namespace Store.Core.Application.Default.Categories.Queries.GetCategoriesByFilter
{
    public class GetCategoriesByFilterQuery : ApplicationRequest<Category, GetCategoriesByFilterQueryResponse>
    {
        public GetCategoriesByFilterQuery()
        {
            ConfigKeys(x => x.Id);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
