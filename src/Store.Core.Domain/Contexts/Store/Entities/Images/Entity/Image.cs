using BAYSOFT.Abstractions.Core.Domain.Entities;
using Store.Core.Domain.Contexts.Store.Entities.Products.Entity;

namespace Store.Core.Domain.Contexts.Store.Entities.Images.Entity
{
    public class Image : DomainEntity<int>
    {
        public string Url { get; set; }
        public string MimeType { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Image()
        {
        }
    }
}
