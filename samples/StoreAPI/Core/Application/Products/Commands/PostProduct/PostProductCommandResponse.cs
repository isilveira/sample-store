using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Core.Application.Products.Commands.PostProduct
{
    public class PostProductCommandResponse
    {
        public PostProductCommand Request { get; set; }
        public string Message { get; set; }
        public PostProductCommandResponseDTO Data { get; set; }
    }
}
