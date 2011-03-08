using AgileWizard.Domain.Models;
using Xunit;

namespace AgileWizard.Website.Tests.Controller
{
    public class WhenLikeAResource : ResourceControllerTestBase
    {
        public WhenLikeAResource()
        {
            resourceControllerSUT.Like(Resource.ID);
        }

        [Fact]
        public void ResourceService_LikeThisResource_ShouldBeCalled()
        {
            _resourceService.Verify(r => r.LikeThisResource(Resource.ID));
        }

        [Fact]
        public void dislike_a_resource()
        {
            //Arrange

            //Act
            resourceControllerSUT.Dislike(Resource.ID);

            //Assert
            _resourceService.Verify(r => r.DislikeThisResource(Resource.ID));
        }
    }
}
