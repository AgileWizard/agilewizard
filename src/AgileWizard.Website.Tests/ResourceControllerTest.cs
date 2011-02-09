using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.Users;
using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Services;
using AgileWizard.Website.Controllers;
using AgileWizard.Website.Models;
using AgileWizard.Website.Tests.Helper;
using Moq;
using Raven.Client;
using Xunit;

namespace AgileWizard.Website.Tests
{
    public class ResourceControllerTest
    {
        private readonly Mock<IResourceService> _resourceService;
        private readonly Mock<IDocumentSession> _documentSession;
        private readonly Mock<ISessionStateRepository> _sessionStateRepository;
        private readonly ResourceController resourceControllerSUT;

        private readonly Resource _resource = Resource.DefaultResource();

        private readonly ResourceDetailViewModel _resourceDetailViewModel = ResourceModelTestHelper.BuildDefaultResourceDetailViewModel();

        public ResourceControllerTest()
        {
            _resourceService = new Mock<IResourceService>();
            _documentSession = new Mock<IDocumentSession>();
            _sessionStateRepository = new Mock<ISessionStateRepository>();
            MvcApplication.ConfigAutoMapper();

            resourceControllerSUT = new ResourceController(_resourceService.Object, _documentSession.Object, _sessionStateRepository.Object);
        }


        [Fact]
        public void when_add_resource()
        {
            //Arrange
            WithDefaultUser();

            ResourceRepositoryWillBeCalled();

            //Act
            var actionResult = resourceControllerSUT.Create(_resourceDetailViewModel);

            //Assert
            _resourceService.VerifyAll();
            ShouldRedirectToActionDetails(actionResult, Resource.ID);
        }

        private void WithDefaultUser()
        {
            _sessionStateRepository.Setup(s => s.CurrentUser).Returns(User.DefaultUser());
        }

        [Fact]
        public void index_action_should_return_a_view_of_a_list_of_resouces()
        {
            //Arrange
            var resources = new List<Resource>
                                {
                                    _resource
                                };
            _resourceService.Setup(s => s.GetResourceList()).Returns(resources);

            //Act
            var actionResult = resourceControllerSUT.Index();

            //Assert
            ShouldShowIndexViewWithModel(actionResult);
        }

        [Fact]
        public void detail_action_should_return_a_view_for_a_resource()
        {
            //Arrange
            _resourceService.Setup(s => s.GetResourceById(Resource.ID)).Returns(_resource);
            var request = new Mock<HttpRequestBase>();
            var context = new Mock<HttpContextBase>();
            context.SetupGet(x => x.Request).Returns(request.Object);
            resourceControllerSUT.ControllerContext = new ControllerContext(context.Object, new RouteData(), resourceControllerSUT);
            _resourceService.Setup(s => s.AddOnePageView(Resource.ID, It.IsAny<string>())).Verifiable();

            //Act
            var actionResult = resourceControllerSUT.Details(Resource.ID);

            //Assert
            ShouldShowDefaultViewWithModel(Resource.DefaultResource().Title, actionResult);
            _resourceService.VerifyAll();
        }

        [Fact]
        public void edit_action_should_return_a_view_for_a_resource()
        {
            //Arrange
            _resourceService.Setup(s => s.GetResourceById(Resource.ID)).Returns(_resource);

            //Act
            var actionResult = resourceControllerSUT.Edit(Resource.ID);

            //Assert
            ShouldShowDefaultViewWithModel(Resource.DefaultResource().Title, actionResult);
        }

        [Fact]
        public void post_edit_action_should_get_original_resource_and_update_it()
        {
            //Arrange
            _sessionStateRepository.Setup(s => s.CurrentUser).Returns(User.DefaultUser());
            _resourceService.Setup(s => s.UpdateResource(Resource.ID, It.IsAny<Resource>())).Verifiable();

            //Act
            var actionResult = resourceControllerSUT.Edit(Resource.ID, _resourceDetailViewModel);

            //Assert
            _resourceService.VerifyAll();
            ShouldRedirectToActionDetails(actionResult, Resource.ID);
        }

        [Fact]
        public void render_user_control_for_resource_list()
        {
            //Arrange
            var resources = new List<Resource>
                                {
                                    _resource
                                };
            _resourceService.Setup(s => s.GetResourceList()).Returns(resources);

            //Act
            var actionResult = resourceControllerSUT.ResourceList();

            //Assert
            ShouldShowResourceListUserControlWithModel(actionResult);
        }

        [Fact]
        public void should_return_resource_list_by_given_tag()
        {
            // Arrange
            _resource.Tags = new List<Resource.ResourceTag>
            {
                new Resource.ResourceTag
                {
                    Name = "agile",
                }
            };

            var resources = new List<Resource> { _resource };
            _resourceService.Setup(s => s.GetResourceListByTag("agile")).Returns(resources);

            // Act
            var viewResult = resourceControllerSUT.ListByTag("agile") as ViewResult;

            // Assert
            var viewModel = (IEnumerable<ResourceListViewModel>)viewResult.ViewData.Model;
            Assert.Equal("agile", viewModel.First().Tags[0].Name);
        }

        private void ShouldShowResourceListUserControlWithModel(ActionResult actionResult)
        {
            Assert.IsType<PartialViewResult>(actionResult);
            var partialViewResult = (PartialViewResult)actionResult;
            Assert.Equal("ResourceList", partialViewResult.ViewName);
            Assert.IsAssignableFrom<IEnumerable<ResourceListViewModel>>(partialViewResult.ViewData.Model);
            var viewModel = (IEnumerable<ResourceListViewModel>)partialViewResult.ViewData.Model;
            Assert.Equal("1", viewModel.First().Id);
        }


        private void ShouldShowDefaultViewWithModel(string title, ActionResult actionResult)
        {
            Assert.IsType<ViewResult>(actionResult);
            var viewResult = (ViewResult)actionResult;
            Assert.Empty(viewResult.ViewName);
            Assert.IsAssignableFrom<ResourceDetailViewModel>(viewResult.ViewData.Model);
            var viewModel = (ResourceDetailViewModel)viewResult.ViewData.Model;
            Assert.Equal(title, viewModel.Title);
        }

        private void ShouldShowIndexViewWithModel(ActionResult actionResult)
        {
            Assert.IsType<ViewResult>(actionResult);
            var viewResult = (ViewResult)actionResult;
            Assert.Empty(viewResult.ViewName);
            Assert.IsAssignableFrom<IEnumerable<ResourceListViewModel>>(viewResult.ViewData.Model);
            var viewModel = (IEnumerable<ResourceListViewModel>)viewResult.ViewData.Model;
            Assert.Equal("1", viewModel.First().Id);
        }

        private void ShouldRedirectToActionDetails(ActionResult actionResult, string id)
        {
            Assert.IsType<RedirectToRouteResult>(actionResult);
            Assert.Equal("Details", ((RedirectToRouteResult)actionResult).RouteValues["action"].ToString());
            Assert.Equal(id, ((RedirectToRouteResult)actionResult).RouteValues["id"].ToString());
        }

        private void ResourceRepositoryWillBeCalled()
        {
            _resourceService.Setup(x => x.AddResource(It.IsAny<Resource>())).Returns(_resource).Verifiable();
        }
    }
}
