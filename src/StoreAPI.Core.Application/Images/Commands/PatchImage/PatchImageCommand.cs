using MediatR;
using ModelWrapper;
using StoreAPI.Core.Application.Bases;
using StoreAPI.Core.Domain.Entities;

namespace StoreAPI.Core.Application.Images.Commands.PatchImage
{
    public class PatchImageCommand : RequestBase<Image, PatchImageCommandResponse>
    {
        public PatchImageCommand()
        {
            ConfigKeys(x => x.ImageID);

            ConfigSuppressedProperties(x => x.Product);
        }
    }
}
