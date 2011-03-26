using AgileWizard.Website.Tests.PageObject;
using AgileWizard.Domain.Models;
using Moq;
using Xunit;

namespace AgileWizard.Website.Tests.Controller.ResourceList
{
    public class WhenResourceList_OfTag_Loaded : ResourceListTest
    {
        public WhenResourceList_OfTag_Loaded()
        {
            Setup_ResourceService_GetResourceListByTag_Expectation();

            _actionResult = _resourceControllerSUT.ListByTag("tag");

            _resourceListPage = new ResourceListPage(_actionResult);
        }

        [Fact]
        public void ResourceService_GetTagListOfFirstPage_ShouldBeCalled()
        {
            _resourceService.Verify(x=>x.GetFirstPage_OfTagResource(It.IsAny<string>()));
        }

        private void Setup_ResourceService_GetResourceListByTag_Expectation()
        {
            _resources = 10.CountOfResouces("tag");
            _resourceService.Setup(x => x.GetFirstPage_OfTagResource(It.IsAny<string>())).Returns(_resources);
        }
    }
}
