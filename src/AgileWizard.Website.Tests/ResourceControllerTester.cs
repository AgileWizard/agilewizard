using AgileWizard.Domain;
using AgileWizard.Domain.Repositories;
using AgileWizard.Website.Controllers;
using AgileWizard.Website.Models;
using Moq;
using Raven.Client;
using Xunit;

namespace AgileWizard.Website.Tests
{
    public class ResourceControllerTester
    {
        private readonly Mock<IResourceRepository> _resourceRepository;
        private readonly Mock<IDocumentSession> _documentSession;
        private readonly ResourceController resourceControllerSUT;
        private ResourceModel _resourceModel = new ResourceModel()
                                                  {
                                                      Title = "title",
                                                      Content = "content"
                                                  };

        public ResourceControllerTester()
        {
            _resourceRepository = new Mock<IResourceRepository>();
            _documentSession = new Mock<IDocumentSession>();

            resourceControllerSUT = new ResourceController(_documentSession.Object, _resourceRepository.Object);
        }


        [Fact]
        public void when_add_resource()
        {
            ResourceRepositoryWillBeCalled();

            resourceControllerSUT.Create(_resourceModel);

            _resourceRepository.VerifyAll();
        }

        private void ResourceRepositoryWillBeCalled()
        {
            _resourceRepository.Setup(x => x.Add(_resourceModel.Title, _resourceModel.Content)).Verifiable();
        }
    }
}
