using System;
using System.Collections.Generic;
using System.Linq;
using AgileWizard.Domain.Models;
using AgileWizard.Website.Helper;
using AgileWizard.Website.Models;
using AgileWizard.Website.Tests.Controller;
using Moq;
using Xunit;

namespace AgileWizard.Website.Tests
{
    public class ResourceListViewServiceTest : ResourceControllerTestBase 
    {
        private readonly ResourceListViewService _ResourceListViewServiceSUT;
        private readonly IList<ResourceListViewModel> _actualResourceListViewModels;
        private List<Resource> _expectedResourceList;
        private IList<ResourceListViewModel> _expectedResourceListViewModels;

        public ResourceListViewServiceTest()
        {
            SetUpResourceServiceGetListExpectation();
            SetUpResourceMapperListMappingExpectation();

            _ResourceListViewServiceSUT = new ResourceListViewService(_resourceService.Object, _resoureMapper.Object);
            long ticksOfCreateTime = DateTime.Now.Ticks;
            _actualResourceListViewModels = _ResourceListViewServiceSUT.GetNextPageOfResource(ticksOfCreateTime);
        }

        [Fact]
        public void ResourceService_GetList_ShouldBeCalled()
        {
            _resourceService.Verify(s => s.GetNextPageOfResource(It.IsAny<long>()));
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

        private void SetUpResourceServiceGetListExpectation()
        {
            _expectedResourceList = 10.CountOfResouces("").ToList();
            _resourceService.Setup(s => s.GetNextPageOfResource(It.IsAny<long>())).Returns(_expectedResourceList);
        }

        protected void SetUpResourceMapperListMappingExpectation()
        {
            _expectedResourceListViewModels = 10.CountOfResourceListViewModelInList();
            _resoureMapper.Setup(s => s.MapFromDomainListToListViewModel(It.IsAny<IList<Resource>>())).Returns(_expectedResourceListViewModels);
        }
    }

}
