using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Core.Application.Categories.Commands.PatchCategory
{
    public class PatchCategoryCommandResponse
    {
        public PatchCategoryCommand Request { get; set; }
        public string Message { get; set; }
        public PatchCategoryCommandResponseDTO Data { get; set; }
    }
}
