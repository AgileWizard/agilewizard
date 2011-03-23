using AgileWizard.Website.Tests.PageObject;
using Xunit;

namespace AgileWizard.Website.Tests.Controller.ResourceList
{
    public class ResourceRecommendation_GetHitTest : ResourceListTest
    {
        public ResourceRecommendation_GetHitTest()
        {
            _actionResult = _resourceControllerSUT.GetHitList();

            _resourceListPage = new ResourceListPage(_actionResult);
        }

        [Fact]
        public void ResourceService_GetLikeList_ShouldBeCalled()
        {
            _resourceService.Verify(x => x.GetHitList());
        }
    }
}
