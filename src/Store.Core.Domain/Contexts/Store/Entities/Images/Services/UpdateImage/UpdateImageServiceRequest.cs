using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using Store.Core.Domain.Contexts.Store.Entities.Images.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.Images.Services.UpdateImage
{
    public class UpdateImageServiceRequest : DomainServiceRequest<Image>
    {
        public UpdateImageServiceRequest(Image payload) : base(payload)
        {
        }
    }
}
