using MediatR;
using ModelWrapper;
using Store.Core.Application.Bases;
using Store.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Core.Application.Images.Commands.PutImage
{
    public class PutImageCommand : RequestBase<Image, PutImageCommandResponse>
    {
        public PutImageCommand()
        {
            ConfigKeys(x => x.ImageID);

            ConfigSuppressedProperties(x => x.Product);
        }
    }
}
