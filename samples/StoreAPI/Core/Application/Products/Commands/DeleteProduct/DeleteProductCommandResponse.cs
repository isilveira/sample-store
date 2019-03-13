using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Core.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandResponse
    {
        public DeleteProductCommand request { get; set; }
        public string Message { get; set; }
        public DeleteProductCommandResponseDTO Data { get; set; }
    }
}
