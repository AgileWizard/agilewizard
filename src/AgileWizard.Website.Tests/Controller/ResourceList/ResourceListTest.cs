using System.Collections.Generic;
using System.Web.Mvc;
using AgileWizard.Domain.Models;
using AgileWizard.Website.Models;
using AgileWizard.Website.Tests.PageObject;
using Moq;
using Xunit;

namespace AgileWizard.Website.Tests.Controller.ResourceList
{
    public abstract class ResourceListTest : ResourceControllerTestBase
    {
        protected ResourceListPage _resourceListPage;
        protected IList<Resource> _resources;

        protected ResourceListTest()
        {
            Setup_ResourceListViewProcessor_Expectation();
        }

        [Fact]
        public void ResoureListViewProcess_Process_ShouldBeCalled()
        {
            _resourceListViewProcessor.Verify(x => x.Process(It.IsAny<IList<Resource>>(), It.IsAny<ViewDataDictionary>()));
        }

        [Fact]
        public void ResourceList_ShouldBeLoaded()
        {
            _resourceListPage.Assert_Load();
        }
    
        protected void Setup_ResourceListViewProcessor_Expectation()
        {
            var resourceListViewModels = 10.CountOfResourceListViewModelInList();
            _resourceListViewProcessor.Setup(s => s.Process(It.IsAny<IList<Resource>>(), It.IsAny<ViewDataDictionary>())).Returns(resourceListViewModels);
        }
    }
}
