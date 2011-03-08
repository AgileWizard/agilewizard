using AgileWizard.Website.Models;
using AgileWizard.Website.Tests.PageObject;
using Moq;
using Xunit;

namespace AgileWizard.Website.Tests.Controller
{
    public abstract class OneResourceUpdateBase : ResourceControllerTestBase
    {
        protected DetailPage _detailPage;

        [Fact]
        public void ShouldRedirectTo_Detail()
        {
            _detailPage.AssertRedirection();
        }

        [Fact]
        public void ResourceMapper_DetailToDomain_ShouldBeCalled()
        {
            _resoureMapper.Verify(x => x.MapFromDetailViewModelToDomain(It.IsAny<ResourceDetailViewModel>()));
        }
    }
}
