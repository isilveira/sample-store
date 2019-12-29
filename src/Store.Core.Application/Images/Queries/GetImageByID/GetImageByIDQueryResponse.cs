using ModelWrapper;
using Store.Core.Application.Bases;
using Store.Core.Domain.Entities;

namespace Store.Core.Application.Images.Queries.GetImageByID
{
    public class GetImageByIDQueryResponse : ResponseBase<Image>
    {
        public GetImageByIDQueryResponse(WrapRequest<Image> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
