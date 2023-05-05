using BAYSOFT.Abstractions.Core.Application;
using ModelWrapper;
using Store.Core.Domain.Contexts.Store.Entities.Images.Entity;
using System;
using System.Collections.Generic;

namespace Store.Core.Application.Contexts.Store.Images.Commands.PutImage
{
    public class PutImageCommandResponse : ApplicationResponse<Image>
    {
        public PutImageCommandResponse(Tuple<int, int, WrapRequest<Image>, Dictionary<string, object>, Dictionary<string, object>, string, long?> tuple) : base(tuple)
        {
        }

        public PutImageCommandResponse(WrapRequest<Image> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
