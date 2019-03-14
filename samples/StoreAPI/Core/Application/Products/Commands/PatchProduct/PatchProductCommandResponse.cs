using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Core.Application.Products.Commands.PatchProduct
{
    public class PatchProductCommandResponse
    {
        public PatchProductCommand Request { get; set; }
        public string Message { get; set; }
        public PatchProductCommandResponseDTO Data { get; set; }
    }
}
