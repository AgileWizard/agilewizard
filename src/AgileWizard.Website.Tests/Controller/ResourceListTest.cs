using System;
using System.Collections.Generic;
using AgileWizard.Website.Models;
using AgileWizard.Website.Tests.PageObject;
using Moq;
using Xunit;

namespace AgileWizard.Website.Tests.Controller
{
    public class ResourceListTest : ResourceControllerTestBase
    {
        protected ResourceListPage _resourceListPage;

        [Fact]
        public void Index_WhenResourcesReturned()
        {
            SetUpResourceListViewServiceExpectation();

            _actionResult = resourceControllerSUT.Index();

            _resourceListPage = new ResourceListPage(_actionResult);

            ResourceList_ShouldBeLoaded();
            TicksOfLastResource_InTheList_ShouldBeKept_WhenResourceReturned();
        }

        [Fact]
        public void Index_WhenNoResourcesReturned()
        {
            SetUpNoResourceListViewServiceExpectation();

            _actionResult = resourceControllerSUT.Index();

            _resourceListPage = new ResourceListPage(_actionResult);

            TicksOfZero_ShouldBeKept_WhenNoResourceReturned();
        }

        [Fact]
        public void NextPage_WhenResourcesReturned()
        {
            SetUpResourceListViewServiceExpectation();

            _actionResult = resourceControllerSUT.ResourceList(DateTime.Now.Ticks);

            _resourceListPage = new ResourceListPage(_actionResult);

            ResourceList_ShouldBeLoaded();
            TicksOfLastResource_InTheList_ShouldBeKept_WhenResourceReturned();
        }

        [Fact]
        public void NextPage_WhenNoResourcesReturned()
        {
            SetUpNoResourceListViewServiceExpectation();

            _actionResult = resourceControllerSUT.ResourceList(DateTime.Now.Ticks);

            _resourceListPage = new ResourceListPage(_actionResult);

            TicksOfZero_ShouldBeKept_WhenNoResourceReturned();
        }

        private void TicksOfZero_ShouldBeKept_WhenNoResourceReturned()
        {
            _resourceListPage.Assert_TicksOfZero_ShouldBeKept();
        }

        private void ResourceList_ShouldBeLoaded()
        {
            _resourceListPage.Assert_Load();
        }

        private void TicksOfLastResource_InTheList_ShouldBeKept_WhenResourceReturned()
        {
            _resourceListPage.Assert_CreateDateTimeOFLastResource_ShouldBeKept();
        }

        protected void SetUpResourceListViewServiceExpectation()
        {
            IList<ResourceListViewModel> resourceListViewModels = 10.CountOfResourceListViewModelInList();
            _resourceListViewService.Setup(s => s.GetNextPageOfResource(It.IsAny<long>())).Returns(resourceListViewModels);
        }

        private void SetUpNoResourceListViewServiceExpectation()
        {
            IList<ResourceListViewModel> resourceListViewModels = 0.CountOfResourceListViewModelInList();
            _resourceListViewService.Setup(s => s.GetNextPageOfResource(It.IsAny<long>())).Returns(resourceListViewModels);
        }
    }
}
