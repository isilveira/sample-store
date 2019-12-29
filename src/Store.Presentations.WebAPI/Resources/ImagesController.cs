using Microsoft.AspNetCore.Mvc;
using Store.Core.Application.Images.Commands.DeleteImage;
using Store.Core.Application.Images.Commands.PatchImage;
using Store.Core.Application.Images.Commands.PostImage;
using Store.Core.Application.Images.Commands.PutImage;
using Store.Core.Application.Images.Queries.GetImageByID;
using Store.Core.Application.Images.Queries.GetImagesByFilter;
using Store.Resources._Bases;
using System.Threading.Tasks;

namespace Store.Resources
{
    public class Images : ResourceControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<GetImagesByFilterQueryResponse>> Get(GetImagesByFilterQuery request)
        {
            return await Send(request);
        }

        [HttpGet("{imageid}")]
        public async Task<ActionResult<GetImageByIDQueryResponse>> Get(GetImageByIDQuery request)
        {
            return await Send(request);
        }
        [HttpPost]
        public async Task<ActionResult<PostImageCommandResponse>> Post(PostImageCommand request)
        {
            return await Send(request);
        }

        [HttpPut("{imageid}")]
        public async Task<ActionResult<PutImageCommandResponse>> Put(PutImageCommand request)
        {
            return await Send(request);
        }

        [HttpPatch("{imageid}")]
        public async Task<ActionResult<PatchImageCommandResponse>> Patch(PatchImageCommand request)
        {
            return await Send(request);
        }

        [HttpDelete("{imageid}")]
        public async Task<ActionResult<DeleteImageCommandResponse>> Delete(DeleteImageCommand request)
        {
            return await Send(request);
        }
    }
}