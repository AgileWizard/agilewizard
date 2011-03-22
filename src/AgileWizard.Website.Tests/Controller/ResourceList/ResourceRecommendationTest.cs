using AgileWizard.Website.Tests.PageObject;
using Xunit;

namespace AgileWizard.Website.Tests.Controller.ResourceList
{
    public class ResourceRecommendationTest : ResourceListTest
    {
        public ResourceRecommendationTest()
        {
            _actionResult = _resourceControllerSUT.GetLikeList();

            _resourceListPage = new ResourceListPage(_actionResult);
        }

        [Fact]
        public void ResourceService_GetLikeList_ShouldBeCalled()
        {
            _resourceService.Verify(x => x.GetLikeList());
        }
    }
}
