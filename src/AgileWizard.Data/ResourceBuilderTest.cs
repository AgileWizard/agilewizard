using System;
using AgileWizard.Domain.Models;
using Xunit;

namespace AgileWizard.Data
{
    public class ResourceBuilderTest
    {
        [Fact]
        public void BuildDefaultResource()
        {
            var defaultResource = ResourceBuilder.AnResource().Build(1);

            Assert.IsType(typeof(Resource), defaultResource);
        }

        [Fact]
        public void CanSpecifyCreateTime()
        {
            const int minsBefore = 1;
            var resource = ResourceBuilder.AnResource().WithCreateUpdateTime(minsBefore).Build(1);

            Assert.Equal(DateTime.Now.Minute - 1, resource.CreateTime.Minute);
        }

        [Fact]
        public void ID_Subfix()
        {
            const int minsBefore = 1;
            var resource = ResourceBuilder
                .AnResource()
                .WithCreateUpdateTime(minsBefore)
                .Build(2);

            Assert.True(resource.Id.EndsWith("2"));
        }

        [Fact]
        public void CanSpecifyTag()
        {
            var resource = ResourceBuilder.AnResource().WithTag("Agile").Build(2);

            Assert.Equal("Agile", resource.Tags[0].Name);
        }
    }
}
