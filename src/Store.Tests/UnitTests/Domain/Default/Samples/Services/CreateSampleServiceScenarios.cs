using Store.Core.Domain.Default.Samples.Entities;
using Store.Core.Domain.Default.Samples.Services;
using Store.Core.Domain.Default.Samples.Services.CreateSample;
using Store.Core.Domain.Default.Samples.Specifications;
using Store.Core.Domain.Default.Samples.Validations.DomainValidations;
using Store.Core.Domain.Default.Samples.Validations.EntityValidations;
using Store.Infrastructures.Data.Default;
using BAYSOFT.Tests.Helpers;
using BAYSOFT.Tests.Helpers.Data.Default;
using BAYSOFT.Tests.Helpers.Data.Default.Samples;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BAYSOFT.Tests.UnitTests.Domain.Default.Samples.Services
{
    [TestClass]
    public class CreateSampleServiceScenarios
    {
        [TestMethod]
        public async Task CREATE_Sample_Should_Not_Return_Exception()
        {
            var contextData = SamplesCollections.GetDefaultCollection();

            using (var context = DefaultDbContextExtensions.GetInMemoryDefaultDbContext().SetupSamples(contextData))
            {
                var reader = new DefaultDbContextReader(context);
                var writer = new DefaultDbContextWriter(context);

                var localizer = GenericHelper.CreateLocalizer<CreateSampleServiceRequestHandler>();

                var validator = new SampleValidator();
                var specification = new SampleDescriptionAlreadyExistsSpecification(reader);
                var specificationsValidator = new CreateSampleSpecificationsValidator(specification);

                var handler = new CreateSampleServiceRequestHandler(writer, localizer, validator, specificationsValidator);

                var sample = new Sample { Description = "Sample - 001 [new]" };

                var request = new CreateSampleServiceRequest(sample);

                var result = await handler.Handle(request, default);

                Assert.IsNotNull(result);
            }
        }
    }
}
