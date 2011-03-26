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
    public class ResourceListViewProcessorTest : ResourceControllerTestBase
    {
        private const string TICKSOFCREATETIME = "ticksOfLastCreateTime";

        private readonly ResourceListViewProcessor _resourceListViewProcessorSUT;
        private readonly IList<ResourceListViewModel> _actualResourceListViewModels;
        private IList<Resource> _resources;
        private IList<ResourceListViewModel> _expectedResourceListViewModels;
        private readonly ViewDataDictionary _viewdata;

        public ResourceListViewProcessorTest()
        {
            SetUpResourceList();
            SetUpResourceMapperListMappingExpectation();

            _viewdata = new ViewDataDictionary();
            _resourceListViewProcessorSUT = new ResourceListViewProcessor( _resoureMapper.Object);
            _actualResourceListViewModels = _resourceListViewProcessorSUT.Process(_resources, _viewdata, "Tag");
        }

        [Fact]
        public void ResourceMapper_DomainToListViewModel_ShouldBeCalled()
        {
            _resoureMapper.Verify(s => s.MapFromDomainListToListViewModel(It.IsAny<IList<Resource>>()));
        }

        [Fact]
        public void ResourceList_ShouldBeLoaded()
        {
            Assert.Equal(_expectedResourceListViewModels, _actualResourceListViewModels);
        }

        [Fact]
        public void Tag_ShouldBeKept_InViewData()
        {
            Assert.Equal("Tag", _viewdata["tagName"]);
        }

        private void SetUpResourceList()
        {
            _resources = 10.CountOfResouces("Tag");
        }

        private void SetUpResourceMapperListMappingExpectation()
        {
            _expectedResourceListViewModels = 10.CountOfResourceListViewModelInList();
            _resoureMapper.Setup(s => s.MapFromDomainListToListViewModel(It.IsAny<IList<Resource>>())).Returns(_expectedResourceListViewModels);
        }
    }
}


