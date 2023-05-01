using BAYSOFT.Abstractions.Core.Domain.Entities;

namespace Store.Core.Domain.Contexts.Store.Entities.Image.Entity
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
