using BAYSOFT.Abstractions.Core.Domain.Entities;

namespace Store.Core.Domain.Contexts.Default.Entities.Sample.Entity
{
    public class Sample : DomainEntity<int>
    {
        public string Description { get; set; }
        public Sample()
        {
        }
    }
}
