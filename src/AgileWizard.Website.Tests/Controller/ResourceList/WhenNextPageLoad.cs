using System;
using AgileWizard.Website.Tests.PageObject;
using Xunit;
using Moq;

namespace AgileWizard.Website.Tests.Controller.ResourceList
{
    public class WhenNextPageLoad : ResourceListTest
    {
        public WhenNextPageLoad()
        {
            var ticksOfAnyDateTime = DateTime.Now.Ticks;
            const string tagName = "Tag";
            
            _actionResult = _resourceControllerSUT.ResourceListOfNextPage(ticksOfAnyDateTime, tagName);
            _resourceListPage = new ResourceListPage(_actionResult);
        }

        [Fact]
        public void ResourceService_GetList_ShouldBeCalled_WithParameters_TicksOfCreateTime_AndTagName()
        {
            _resourceService.Verify(x => x.GetResourceList(It.IsAny<long>(), It.IsAny<string>()));
        }
    }
}
