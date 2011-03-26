using AgileWizard.Website.Tests.PageObject;
using AgileWizard.Domain.Models;
using Moq;
using Xunit;

namespace AgileWizard.Website.Tests.Controller.ResourceList
{
    public class WhenIndexLoad : ResourceListTest
    {
        public WhenIndexLoad()
        {
            Setup_ResourceService_GetList_Expectation();

            _actionResult = _resourceControllerSUT.Index();

            _resourceListPage = new ResourceListPage(_actionResult);
        }

        [Fact]
        public void ResourceService_GetListOfFirstPage_ShouldBeCalled()
        {
            _resourceService.Verify(x=>x.GetFirstPage_OfResource());
        }

        private void Setup_ResourceService_GetList_Expectation()
        {
            _resources = 10.CountOfResouces("tag");
            _resourceService.Setup(x => x.GetFirstPage_OfResource()).Returns(_resources);
        }
    }
}
