using System.Collections.Generic;
using AgileWizard.Domain.Models;
using Xunit;

namespace AgileWizard.Data
{
    public class ResourceListBuilderTest
    {
        [Fact]
        public void DefaultResourceList()
        {
            var defaultResourceList = ResourceListBuilder.AnResourceList().Build();

            Assert.IsType(typeof (List<Resource>), defaultResourceList);
        }

        [Fact]
        public void DefaultResourceList_HasOneResource_OfOnePage()
        {
            var defaultResourceList = ResourceListBuilder.AnResourceList().Build();

            Assert.Equal(1, defaultResourceList.Count);
        }

        [Fact]
        public void CanSpecifyPage_OfResources()
        {
            var multiplePageOfResource = ResourceListBuilder.AnResourceList().OfPage(2).Build();

            Assert.Equal(21, multiplePageOfResource.Count);
        }

        [Fact]
        public void CanHave_DifferentCreateUpdateTime()
        {
            var multiplePageOfResource = ResourceListBuilder.
                AnResourceList().
                WithDifferentCreateUpdateTime().
                OfPage(2).
                Build();

            Assert.Equal(21, multiplePageOfResource.Count);

            Assert.True(multiplePageOfResource[0].CreateTime > multiplePageOfResource[1].CreateTime);
            Assert.True(multiplePageOfResource[1].CreateTime > multiplePageOfResource[2].CreateTime);
        }

        [Fact]
        public void ID_ShouldBeDifferent()
        {
            var multiplePageOfResource = ResourceListBuilder
                .AnResourceList()
                .WithDifferentCreateUpdateTime()
                .OfPage(2)
                .Build();

            Assert.Equal(21, multiplePageOfResource.Count);

            Assert.True(multiplePageOfResource[0].Id.EndsWith("0"));
            Assert.True(multiplePageOfResource[1].Id.EndsWith("1"));
        }

        [Fact]
        public void CanSpecifyTag()
        {
            var multiplePageOfResource = ResourceListBuilder
                .AnResourceList()
                .WithTag("Agile")
                .OfPage(2)
                .Build();

            Assert.Equal("Agile", multiplePageOfResource[0].Tags[0].Name);
        }
    }
}
