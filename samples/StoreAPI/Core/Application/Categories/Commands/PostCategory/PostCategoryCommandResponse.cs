using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Core.Application.Categories.Commands.PostCategory
{
    public class PostCategoryCommandResponse
    {
        public PostCategoryCommand Request { get; set; }
        public string Message { get; set; }
        public PostCategoryCommandResponseDTO Data { get; set; }
    }
}
