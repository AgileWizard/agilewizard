using AgileWizard.Domain.Models;
using Moq;
using Xunit;

namespace AgileWizard.Website.Tests.Controller
{
    public abstract class OneResourceLoadBase : ResourceControllerTestBase
    {
        protected OneResourceLoadBase()
        {
            //Arrange
            ResourceService_GetResourceByID_ShouldBeCalled();
            ResourceMapperDomainToDetailViewModelWillBeCalled();
        }

        [Fact]
        public void ResourceService_GetByID_ShouldBeCalled()
        {
            _resourceService.Verify(s => s.GetResourceById(It.IsAny<string>()));
        }

        [Fact]
        public void ResourceMapper_FromDomainToDetailViewModel_ShouldBeCalled()
        {
            _resoureMapper.Verify(s => s.MapFromDomainToDetailViewModel(It.IsAny<Resource>()));
        }

        protected void ResourceMapperDomainToDetailViewModelWillBeCalled()
        {
            _resoureMapper.Setup(s => s.MapFromDomainToDetailViewModel(_resource)).Returns(_resourceDetailViewModel);
        }
    }
}
