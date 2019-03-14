using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Core.Application.Categories.Commands.PutCategory
{
    public class PutCategoryCommandResponse
    {
        public PutCategoryCommand Request { get; set; }
        public string Message { get; set; }
        public PutCategoryCommandResponseDTO Data { get; set; }
    }
}
