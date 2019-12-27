using Microsoft.AspNetCore.Mvc;
using StoreAPI.Core.Application.Images.Commands.DeleteImage;
using StoreAPI.Core.Application.Images.Commands.PatchImage;
using StoreAPI.Core.Application.Images.Commands.PostImage;
using StoreAPI.Core.Application.Images.Commands.PutImage;
using StoreAPI.Core.Application.Images.Queries.GetImageByID;
using StoreAPI.Core.Application.Images.Queries.GetImagesByFilter;
using StoreAPI.Resources._Bases;
using System.Threading.Tasks;

namespace StoreAPI.Resources
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