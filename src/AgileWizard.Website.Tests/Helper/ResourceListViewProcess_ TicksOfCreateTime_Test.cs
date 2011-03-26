using System.Collections.Generic;
using System.Web.Mvc;
using AgileWizard.Domain.Models;
using AgileWizard.Website.Helper;
using AgileWizard.Website.Models;
using AgileWizard.Website.Tests.Controller;
using Moq;
using Xunit;

namespace AgileWizard.Website.Tests.Helper
{
    public class ResourceListViewProcess__TicksOfCreateTime_Test : ResourceControllerTestBase
    {
        private const string TICKSOFCREATETIME = "ticksOfLastCreateTime";

        private ResourceListViewProcessor _resourceListViewProcessorSUT;
        private IList<Resource> _resources;
        private IList<ResourceListViewModel> _expectedResourceListViewModels;
        private ViewDataDictionary _viewdata;

        public ResourceListViewProcess__TicksOfCreateTime_Test()
        {
            SetUpResourceList();
            _viewdata = new ViewDataDictionary();
        }

        [Fact]
        public void TicksOfLastResource_InTheList_ShouldBeKept_InViewData_WhenResourceReturned()
        {
            SetUp_ResourceMapperListMapping_Expectation();

            ProcessList();

            var ticksOfLastCreateTime = _expectedResourceListViewModels[_resources.Count - 1].CreateTime.Ticks;
            Assert.Equal(_viewdata[TICKSOFCREATETIME], ticksOfLastCreateTime);
        }

        [Fact]
        public void Zero_ShouldBeKept_InViewData_WhenNoResourceReturned()
        {
            SetUpResourceList();
            SetUp_EmptyResourceMapperListMapping_Expectation();

            ProcessList();

            const long ticksOfLastCreateTime = 0;
            Assert.Equal(_viewdata[TICKSOFCREATETIME], ticksOfLastCreateTime);
        }

         private void SetUpResourceList()
        {
            _resources = 10.CountOfResouces("Tag");
        }

        private void SetUp_ResourceMapperListMapping_Expectation()
        {
            _expectedResourceListViewModels = 10.CountOfResourceListViewModelInList();
            _resoureMapper.Setup(s => s.MapFromDomainListToListViewModel(It.IsAny<IList<Resource>>())).Returns(_expectedResourceListViewModels);
        }

        private void SetUp_EmptyResourceMapperListMapping_Expectation()
        {
            _expectedResourceListViewModels = new List<ResourceListViewModel>();
            _resoureMapper.Setup(s => s.MapFromDomainListToListViewModel(It.IsAny<IList<Resource>>())).Returns(_expectedResourceListViewModels);
        }

        private void ProcessList()
        {
            _resourceListViewProcessorSUT = new ResourceListViewProcessor(_resoureMapper.Object);
            _resourceListViewProcessorSUT.Process(_resources, _viewdata, "Tag");
        }
    }
}
