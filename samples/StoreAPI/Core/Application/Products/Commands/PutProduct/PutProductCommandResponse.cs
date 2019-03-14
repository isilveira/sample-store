using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Core.Application.Products.Commands.PutProduct
{
    public class PutProductCommandResponse
    {
        public PutProductCommand Request { get; set; }
        public string Message { get; set; }
        public PutProductCommandResponseDTO Data { get; set; }
    }
}
