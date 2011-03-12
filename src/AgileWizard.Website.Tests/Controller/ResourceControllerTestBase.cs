using System.Web.Mvc;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Services;
using AgileWizard.Website.Controllers;
using AgileWizard.Website.Helper;
using AgileWizard.Website.Mapper;
using AgileWizard.Website.Models;
using AgileWizard.Website.Tests.Helper;
using Moq;
using Raven.Client;

namespace AgileWizard.Website.Tests.Controller
{
    public class ResourceControllerTestBase
    {
        #region Fields
        
        protected readonly Mock<IResourceService> _resourceService;
        protected readonly Mock<ISessionStateRepository> _sessionStateRepository;
        protected readonly Mock<IDocumentSession> _documentSession;
        protected readonly Mock<IResourceMapper> _resoureMapper;
        protected readonly Mock<IResourceListViewService> _resourceListViewService;

        protected readonly Resource _resource = Resource.DefaultResource();
        protected readonly ResourceDetailViewModel _resourceDetailViewModel = ResourceModelTestHelper.BuildDefaultResourceDetailViewModel();

        protected readonly ResourceController resourceControllerSUT;

        protected ActionResult _actionResult;
        #endregion

        protected ResourceControllerTestBase()
        {
            _resourceService = new Mock<IResourceService>();
            _sessionStateRepository = new Mock<ISessionStateRepository>();
            _documentSession = new Mock<IDocumentSession>();
            _resoureMapper = new Mock<IResourceMapper>();
            _resourceListViewService = new Mock<IResourceListViewService>();

            ResourceMapper.ConfigAutoMapper();

            resourceControllerSUT = new ResourceController(_resourceService.Object, _documentSession.Object, _sessionStateRepository.Object, _resoureMapper.Object, _resourceListViewService.Object);
        }

        protected void ResourceServiceGetResourceByIDWillBeCalled()
        {
            _resourceService.Setup(s => s.GetResourceById(Resource.ID)).Returns(_resource);
        }
    }
}
