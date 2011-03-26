using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileWizard.Website.Tests.PageObject;
using Xunit;

namespace AgileWizard.Website.Tests.Controller.ResourceList
{
    public class ResourceRecommendation_GetLatestTest : ResourceListTest
    {
        public ResourceRecommendation_GetLatestTest()
        {
            _actionResult = _resourceControllerSUT.GetLatestList();

            _resourceListPage = new ResourceListPage(_actionResult);
        }

        [Fact]
        public void ResourceService_GetLikeList_ShouldBeCalled()
        {
            _resourceService.Verify(x => x.GetLatestList());
        }
    }
}
