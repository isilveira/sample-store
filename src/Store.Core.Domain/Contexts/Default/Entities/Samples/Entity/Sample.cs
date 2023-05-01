using BAYSOFT.Abstractions.Core.Domain.Entities;

namespace Store.Core.Domain.Contexts.Default.Entities.Samples.Entity
{
    public class Sample : DomainEntity<int>
    {
        public string Description { get; set; }
        public Sample()
        {
        }
    }
}
