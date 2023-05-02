using BAYSOFT.Abstractions.Core.Domain.Entities.Specifications;
using Store.Core.Domain.Contexts.Default.Entities.Samples.Entity;
using Store.Core.Domain.Contexts.Default.Interfaces.Infrastructures.Data;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Store.Core.Domain.Contexts.Default.Entities.Samples.Validations.Specifications.Default.Samples
{
    public class SampleDescriptionAlreadyExistsSpecification : DomainSpecification<Sample>
    {
        private IDeafultDbContextReader Reader { get; set; }
        public SampleDescriptionAlreadyExistsSpecification(IDeafultDbContextReader reader)
        {
            Reader = reader;
        }

        public override Expression<Func<Sample, bool>> ToExpression()
        {
            return sample => Reader.Query<Sample>().Any(x => x.Description == sample.Description && x.Id != sample.Id);
        }
    }
}
