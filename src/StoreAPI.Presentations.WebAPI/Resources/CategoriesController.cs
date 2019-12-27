using Microsoft.AspNetCore.Mvc;
using StoreAPI.Core.Application.Categories.Commands.DeleteCategory;
using StoreAPI.Core.Application.Categories.Commands.PatchCategory;
using StoreAPI.Core.Application.Categories.Commands.PostCategory;
using StoreAPI.Core.Application.Categories.Commands.PutCategory;
using StoreAPI.Core.Application.Categories.Queries.GetCategoriesByFilter;
using StoreAPI.Core.Application.Categories.Queries.GetCategoryByID;
using StoreAPI.Resources._Bases;
using System.Threading.Tasks;

namespace StoreAPI.Resources
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