using AgileWizard.Domain.Models;
using AgileWizard.Website.Tests.PageObject;
using Moq;
using Xunit;

namespace AgileWizard.Website.Tests.Controller
{
    public class WhenAddResource : OneResourceUpdateBase
    {
        public WhenAddResource()
        {
            //Arrange
            WillSaveResourceToService();

            //Act
            _actionResult = resourceControllerSUT.Create(_resourceDetailViewModel);

            _detailPage = new DetailPage(_actionResult);
        }

        [Fact]
        public void ResourceService_Add_ShouldBeCalled()
        {
            _resourceService.Verify(x => x.AddResource(It.IsAny<Resource>()));
        }

        private void WillSaveResourceToService()
        {
            _resourceService.Setup(x => x.AddResource(It.IsAny<Resource>())).Returns(_resource);
        }
    }
}
