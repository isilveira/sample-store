using ModelWrapper;
using Store.Core.Application.Bases;
using Store.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Core.Application.Images.Commands.PutImage
{
    public class PutImageCommandResponse : ResponseBase<Image>
    {
        public PutImageCommandResponse(WrapRequest<Image> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
