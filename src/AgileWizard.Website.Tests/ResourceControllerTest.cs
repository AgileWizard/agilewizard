using System;
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
using Moq;
using Raven.Client;
using Xunit;

namespace AgileWizard.Website.Tests
{
    public class ResourceControllerTest
    {
        private const string ID = "1";
        private const string DOCUMENT_ID = "resources/1";
        private const string TITLE = "title";
        private const string CONTENT = "content";
        private const string AUTHOR = "author";
        private const string SUBMITUSER = "submitUser";
        private const string REFERENCE_URL = "http://www.cnblogs.com/tengzy/";

        private readonly Mock<IResourceService> _resourceService;
        private readonly Mock<IDocumentSession> _documentSession;
        private readonly Mock<ISessionStateRepository> _sessionStateRepository;
        private readonly ResourceController resourceControllerSUT;

        private readonly Resource _resource = new Resource()
                                         {
                                             Id = DOCUMENT_ID,
                                             Title = TITLE,
                                             Content = CONTENT,
                                             Author = AUTHOR,
                                             ReferenceUrl = REFERENCE_URL,
                                             SubmitUser = SUBMITUSER
                                         };
        private readonly ResourceModel _resourceModel = new ResourceModel()
                                                  {
                                                      Id = ID,
                                                      Title = TITLE,
                                                      Content = CONTENT,
                                                      Author = AUTHOR,
                                                      ReferenceUrl = REFERENCE_URL
                                                  };

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
            _sessionStateRepository.Setup(s => s.CurrentUser).Returns(User.DefaultUser());

            ResourceRepositoryWillBeCalled();


            //Act
            var actionResult = resourceControllerSUT.Create(_resourceModel);

            //Assert
            _resourceService.VerifyAll();
            ShouldRedirectToActionDetails(actionResult, ID);
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
            _resourceService.Setup(s => s.GetResourceById(ID)).Returns(_resource);
            var request = new Mock<HttpRequestBase>();
            var context = new Mock<HttpContextBase>();
            context.SetupGet(x => x.Request).Returns(request.Object);
            resourceControllerSUT.ControllerContext = new ControllerContext(context.Object, new RouteData(), resourceControllerSUT);
            _resourceService.Setup(s => s.AddOnePageView(ID, It.IsAny<string>())).Verifiable();

            //Act
            var actionResult = resourceControllerSUT.Details(ID);

            //Assert
            ShouldShowDefaultViewWithModel(TITLE, actionResult);
            _resourceService.VerifyAll();
        }

        [Fact]
        public void edit_action_should_return_a_view_for_a_resource()
        {
            //Arrange
            _resourceService.Setup(s => s.GetResourceById(ID)).Returns(_resource);

            //Act
            var actionResult = resourceControllerSUT.Edit(ID);

            //Assert
            ShouldShowDefaultViewWithModel(TITLE, actionResult);
        }

        [Fact]
        public void post_edit_action_should_get_original_resource_and_update_it()
        {
            //Arrange
            _sessionStateRepository.Setup(s => s.CurrentUser).Returns(User.DefaultUser());
            _resourceService.Setup(s => s.UpdateResource(ID, It.Is<Resource>(r => r.Title == TITLE && r.Content == CONTENT && r.Author == AUTHOR && r.ReferenceUrl == REFERENCE_URL && r.SubmitUser == User.DefaultUser().UserName))).Verifiable();

            //Act
            var actionResult = resourceControllerSUT.Edit(ID, _resourceModel);

            //Assert
            _resourceService.VerifyAll();
            ShouldRedirectToActionDetails(actionResult, ID);
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
            Assert.IsAssignableFrom<ResourceModel>(viewResult.ViewData.Model);
            var viewModel = (ResourceModel)viewResult.ViewData.Model;
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
            _resourceService.Setup(x => x.AddResource(It.Is<Resource>(r => r.Title == _resourceModel.Title
                && r.Author == _resourceModel.Author
                && r.Content == _resourceModel.Content
                && r.ReferenceUrl == _resourceModel.ReferenceUrl
                && r.SubmitUser == _sessionStateRepository.Object.CurrentUser.UserName
                && r.Tags.Count == 0))).Returns(_resource).Verifiable();
        }
    }
}
