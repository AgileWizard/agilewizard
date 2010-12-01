using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Services;
using AgileWizard.Website.Controllers;
using AgileWizard.Website.Models;
using Moq;
using Raven.Client;
using Xunit;

namespace AgileWizard.Website.Tests
{
    public class ResourceControllerTest
    {
        private readonly Mock<IResourceService> _resourceService;
        private readonly Mock<IDocumentSession> _documentSession;
        private readonly ResourceController resourceControllerSUT;
        private ResourceModel _resourceModel = new ResourceModel()
                                                  {
                                                      Title = "title",
                                                      Content = "content"
                                                  };

        public ResourceControllerTest()
        {
            _resourceService = new Mock<IResourceService>();
            _documentSession = new Mock<IDocumentSession>();

            resourceControllerSUT = new ResourceController(_documentSession.Object, _resourceService.Object);
        }


        [Fact]
        public void when_add_resource()
        {
            ResourceRepositoryWillBeCalled();

            resourceControllerSUT.Create(_resourceModel);

            _resourceService.VerifyAll();
        }

        private void ResourceRepositoryWillBeCalled()
        {
            _resourceService.Setup(x => x.AddResource(_resourceModel.Title, _resourceModel.Content)).Verifiable();
        }
    }
}
