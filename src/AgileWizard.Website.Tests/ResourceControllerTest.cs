using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AgileWizard.Domain.Entities;
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
            //Arrange
            ResourceRepositoryWillBeCalled();

            //Act
            var actionResult = resourceControllerSUT.Create(_resourceModel);

            //Assert
            _resourceService.VerifyAll();
            ShouldRedirectToActionIndex(actionResult);
        }

        [Fact]
        public void index_action_should_return_a_view_of_a_list_of_resouces()
        {
            //Arrange
            var resources = new List<Resource>
                                {
                                    new Resource() {Id = "resources/1", Title = "title", Content = "content"}
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
            const string ID = "1";
            const string TITLE = "title";
            var resource = new Resource() {Title = TITLE};
            _resourceService.Setup(s => s.GetResourceById(ID)).Returns(resource);

            //Act
            var actionResult = resourceControllerSUT.Details(ID);

            //Assert
            ShouldShowDefaultViewWithModel(TITLE, actionResult);
        }

        public void edit_action_should_return_a_view_for_a_resource()
        {
            //Arrange
            const string ID = "1";
            const string TITLE = "title";
            var resource = new Resource() { Title = TITLE };
            _resourceService.Setup(s => s.GetResourceById(ID)).Returns(resource);

            //Act
            var actionResult = resourceControllerSUT.Details(ID);

            //Assert
            ShouldShowDefaultViewWithModel(TITLE, actionResult);
        }

        private void ShouldShowDefaultViewWithModel(string title, ActionResult actionResult)
        {
            Assert.IsType<ViewResult>(actionResult);
            var viewResult = (ViewResult) actionResult;
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

        private void ShouldRedirectToActionIndex(ActionResult actionResult)
        {
            Assert.IsType<RedirectToRouteResult>(actionResult);
            Assert.Equal("Index", ((RedirectToRouteResult)actionResult).RouteValues["action"].ToString());
        }

        private void ResourceRepositoryWillBeCalled()
        {
            _resourceService.Setup(x => x.AddResource(_resourceModel.Title, _resourceModel.Content)).Verifiable();
        }
    }
}
