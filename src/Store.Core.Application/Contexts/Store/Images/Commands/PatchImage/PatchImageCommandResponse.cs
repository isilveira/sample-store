using BAYSOFT.Abstractions.Core.Application;
using ModelWrapper;
using Store.Core.Domain.Contexts.Store.Entities.Images.Entity;
using System;
using System.Collections.Generic;

namespace Store.Core.Application.Contexts.Store.Images.Commands.PatchImage
{
    public class PatchImageCommandResponse : ApplicationResponse<Image>
    {
        public PatchImageCommandResponse(Tuple<int, int, WrapRequest<Image>, Dictionary<string, object>, Dictionary<string, object>, string, long?> tuple) : base(tuple)
        {
        }

        public PatchImageCommandResponse(WrapRequest<Image> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
