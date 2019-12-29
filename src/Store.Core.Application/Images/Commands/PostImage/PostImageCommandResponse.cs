using ModelWrapper;
using Store.Core.Application.Bases;
using Store.Core.Domain.Entities;
using System.Collections.Generic;

namespace Store.Core.Application.Images.Commands.PostImage
{
    public class PostImageCommandResponse : ResponseBase<Image>
    {
        public PostImageCommandResponse(WrapRequest<Image> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
