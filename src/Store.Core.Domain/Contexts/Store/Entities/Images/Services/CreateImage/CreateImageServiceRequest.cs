using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using Store.Core.Domain.Contexts.Store.Entities.Images.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.Images.Services.CreateImage
{
    public class CreateImageServiceRequest : DomainServiceRequest<Image>
    {
        public CreateImageServiceRequest(Image payload) : base(payload)
        {
        }
    }
}
