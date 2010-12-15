using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AgileWizard.Domain.Resources;
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
                                             SubmitUser = SUBMITUSER
                                         };
        private readonly ResourceModel _resourceModel = new ResourceModel()
                                                  {
                                                      Id = ID,
                                                      Title = TITLE,
                                                      Content = CONTENT,
                                                      Author = AUTHOR
                                                  };

        public ResourceControllerTest()
        {
            _resourceService = new Mock<IResourceService>();
            _documentSession = new Mock<IDocumentSession>();
            _sessionStateRepository = new Mock<ISessionStateRepository>();

            resourceControllerSUT = new ResourceController(_resourceService.Object, _documentSession.Object, _sessionStateRepository.Object);
        }


        [Fact]
        public void when_add_resource()
        {
            //Arrange
            _sessionStateRepository.Setup(s => s.CurrentUser).Returns(User.EmptyUser());

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

            //Act
            var actionResult = resourceControllerSUT.Details(ID);

            //Assert
            ShouldShowDefaultViewWithModel(TITLE, actionResult);
        }

        [Fact]
        public void edit_action_should_return_a_view_for_a_resource()
        {
            //Arrange
            _resourceService.Setup(s => s.GetResourceById(ID)).Returns(_resource);

            //Act
            var actionResult = resourceControllerSUT.Details(ID);

            //Assert
            ShouldShowDefaultViewWithModel(TITLE, actionResult);
        }

        [Fact]
        public void post_edit_action_should_get_original_resource_and_update_it()
        {
            //Arrange
            _sessionStateRepository.Setup(s => s.CurrentUser).Returns(User.EmptyUser());
            _resourceService.Setup(s => s.UpdateResource(ID, It.Is<Resource>(r => r.Title == TITLE && r.Content == CONTENT && r.Author == AUTHOR && r.SubmitUser == User.EmptyUser().UserName))).Verifiable();

            //Act
            var actionResult = resourceControllerSUT.Edit(ID, _resourceModel);

            //Assert
            _resourceService.VerifyAll();
            ShouldRedirectToActionDetails(actionResult, ID);
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
            Assert.IsAssignableFrom<IEnumerable<ResourceModel>>(viewResult.ViewData.Model);
            var viewModel = (IEnumerable<ResourceModel>)viewResult.ViewData.Model;
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
            _resourceService.Setup(x => x.AddResource(_resourceModel.Title, _resourceModel.Content, _resourceModel.Author, _sessionStateRepository.Object.CurrentUser.UserName)).Returns(_resource).Verifiable();
        }
    }
}
