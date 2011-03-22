using AgileWizard.Domain.Models;
using Xunit;

namespace AgileWizard.Website.Tests.Controller
{
    public class WhenDislikeAResource : ResourceControllerTestBase
    {
        public WhenDislikeAResource()
        {
            _resourceControllerSUT.Dislike(Resource.ID);
        }

        [Fact]
        public void ResourceService_DislikeThisResource_ShouldBeCalled()
        {
            _resourceService.Verify(r => r.DislikeThisResource(Resource.ID));
        }
    }
}
