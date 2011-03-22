using AgileWizard.Domain.Models;
using AgileWizard.Website.Tests.PageObject;
using Moq;
using Xunit;

namespace AgileWizard.Website.Tests.Controller
{
    public class WhenEditResourceUpdate : OneResourceUpdateBase
    {
        public WhenEditResourceUpdate()
        {
            _actionResult = _resourceControllerSUT.Edit(Resource.ID, _resourceDetailViewModel);

            _detailPage = new DetailPage(_actionResult);
        }

        [Fact]
        public void ResourceService_Update_ShouldBeCalled()
        {
            _resourceService.Verify(s => s.UpdateResource(Resource.ID, It.IsAny<Resource>()));
        }
    }
}
