using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using Store.Core.Domain.Contexts.Store.Entities.Images.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.Images.Services.DeleteImage
{
    public class DeleteImageServiceRequest : DomainServiceRequest<Image>
    {
        public DeleteImageServiceRequest(Image payload) : base(payload)
        {
        }
    }
}
