using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Core.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandResponse
    {
        public DeleteCategoryCommand Request { get; set; }
        public string Message { get; set; }
        public DeleteCategoryCommandResponseDTO Data { get; set; }
    }
}
