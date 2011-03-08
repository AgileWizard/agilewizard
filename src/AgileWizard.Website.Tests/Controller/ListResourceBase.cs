using System.Collections.Generic;
using AgileWizard.Domain.Models;
using AgileWizard.Website.Tests.PageObject;
using Moq;
using Xunit;

namespace AgileWizard.Website.Tests.Controller
{
    public abstract class ResourceListBase : ResourceControllerTestBase
    {
        protected IndexListPage IndexListPage;

        protected ResourceListBase()
        {
            SetUpResourceMapperListMappingExpectation();
        }

        [Fact]
        public void ResourceMapper_DomainToListViewModel_ShouldBeCalled()
        {
            _resoureMapper.Verify(s => s.MapFromDomainListToListViewModel(It.IsAny<IList<Resource>>()));
        }

        [Fact]
        public void ResourceList_ShouldBeLoaded()
        {
            IndexListPage.Assert_Load();
        }
    }
}
