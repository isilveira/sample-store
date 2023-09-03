using BAYSOFT.Abstractions.Core.Domain.Entities.Specifications;
using Store.Core.Domain.Default.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Default.Samples.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Store.Core.Domain.Default.Samples.Specifications
{
    public class SampleDescriptionAlreadyExistsSpecification : DomainSpecification<Sample>
    {
        private IDefaultDbContextReader Reader { get; set; }
        public SampleDescriptionAlreadyExistsSpecification(IDefaultDbContextReader reader)
        {
            Reader = reader;
            SpecificationMessage = "A register with this description already exists!";
        }

        public override Expression<Func<Sample, bool>> ToExpression()
        {
            return sample => Reader.Query<Sample>().Any(x =>
                x.Description.ToLower().Equals(sample.Description.ToLower())
                && x.Id != sample.Id
            );
        }
    }
}
