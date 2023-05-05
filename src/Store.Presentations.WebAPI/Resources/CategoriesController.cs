using Store.Presentations.WebAPI.Abstractions.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Store.Core.Application.Contexts.Store.Categories.Commands.DeleteCategory;
using Store.Core.Application.Contexts.Store.Categories.Commands.PatchCategory;
using Store.Core.Application.Contexts.Store.Categories.Commands.PostCategory;
using Store.Core.Application.Contexts.Store.Categories.Commands.PutCategory;
using Store.Core.Application.Contexts.Store.Categories.Queries.GetCategoriesByFilter;
using Store.Core.Application.Contexts.Store.Categories.Queries.GetCategoryById;

namespace Store.Resources
{
    public class CategoriesController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetCategoriesByFilterQueryResponse>> Get(GetCategoriesByFilterQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCategoryByIdQueryResponse>> Get(GetCategoryByIdQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<PostCategoryCommandResponse>> Post(PostCategoryCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PutCategoryCommandResponse>> Put(PutCategoryCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<PatchCategoryCommandResponse>> Patch(PatchCategoryCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteCategoryCommandResponse>> Delete(DeleteCategoryCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }
    }
}
