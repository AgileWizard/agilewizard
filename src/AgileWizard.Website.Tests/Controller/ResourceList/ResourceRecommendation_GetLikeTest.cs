using AgileWizard.Website.Tests.PageObject;
using Xunit;

namespace AgileWizard.Website.Tests.Controller.ResourceList
{
    public class ResourceRecommendation_GetLikeTest : ResourceListTest
    {
        public ResourceRecommendation_GetLikeTest()
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
