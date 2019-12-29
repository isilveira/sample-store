using Microsoft.AspNetCore.Mvc;
using Store.Core.Application.Categories.Commands.DeleteCategory;
using Store.Core.Application.Categories.Commands.PatchCategory;
using Store.Core.Application.Categories.Commands.PostCategory;
using Store.Core.Application.Categories.Commands.PutCategory;
using Store.Core.Application.Categories.Queries.GetCategoriesByFilter;
using Store.Core.Application.Categories.Queries.GetCategoryByID;
using Store.Resources._Bases;
using System.Threading.Tasks;

namespace Store.Resources
{
    public class CategoriesController : ResourceControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<GetCategoriesByFilterQueryResponse>> Get(GetCategoriesByFilterQuery request)
        {
            return await Send(request);
        }

        [HttpGet("{categoryid}")]
        public async Task<ActionResult<GetCategoryByIDQueryResponse>> Get(GetCategoryByIDQuery request)
        {
            return await Send(request);
        }
        [HttpPost]
        public async Task<ActionResult<PostCategoryCommandResponse>> Post(PostCategoryCommand request)
        {
            return await Send(request);
        }

        [HttpPut("{categoryid}")]
        public async Task<ActionResult<PutCategoryCommandResponse>> Put(PutCategoryCommand request)
        {
            return await Send(request);
        }

        [HttpPatch("{categoryid}")]
        public async Task<ActionResult<PatchCategoryCommandResponse>> Patch(PatchCategoryCommand request)
        {
            return await Send(request);
        }

        [HttpDelete("{categoryid}")]
        public async Task<ActionResult<DeleteCategoryCommandResponse>> Delete(DeleteCategoryCommand request)
        {
            return await Send(request);
        }
    }
}