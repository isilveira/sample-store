using Store.Presentations.WebAPI.Abstractions.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Store.Core.Application.Contexts.Store.Images.Commands.DeleteImage;
using Store.Core.Application.Contexts.Store.Images.Commands.PatchImage;
using Store.Core.Application.Contexts.Store.Images.Commands.PostImage;
using Store.Core.Application.Contexts.Store.Images.Commands.PutImage;
using Store.Core.Application.Contexts.Store.Images.Queries.GetImageById;
using Store.Core.Application.Contexts.Store.Images.Queries.GetImagesByFilter;

namespace Store.Resources
{
    public class ImagesController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetImagesByFilterQueryResponse>> Get(GetImagesByFilterQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetImageByIdQueryResponse>> Get(GetImageByIdQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<PostImageCommandResponse>> Post(PostImageCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PutImageCommandResponse>> Put(PutImageCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<PatchImageCommandResponse>> Patch(PatchImageCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteImageCommandResponse>> Delete(DeleteImageCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }
    }
}
