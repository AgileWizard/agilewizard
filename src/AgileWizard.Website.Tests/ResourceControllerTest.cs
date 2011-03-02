using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.Users;
using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Services;
using AgileWizard.Website.Controllers;
using AgileWizard.Website.Models;
using AgileWizard.Website.Tests.Helper;
using AgileWizard.Website.Tests.PageObject;
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
            ResourceMapper.ConfigAutoMapper();

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
            _resourceService.Verify(x=>x.AddResource(It.IsAny<Resource>()));

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
            SetUpDefaultResourceListExpectation();

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

            //Act
            var actionResult = resourceControllerSUT.Details(Resource.ID);

            //Assert
            ShouldShowDefaultViewWithModel(Resource.DefaultResource().Title, actionResult);
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

            //Act
            var actionResult = resourceControllerSUT.Edit(Resource.ID, _resourceDetailViewModel);

            //Assert
            _resourceService.Verify(s => s.UpdateResource(Resource.ID, It.IsAny<Resource>()));
            ShouldRedirectToActionDetails(actionResult, Resource.ID);
        }

        [Fact]
        public void render_user_control_for_resource_list()
        {
            //Arrange
            SetUpDefaultResourceListExpectation();

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

        [Fact]
        public void like_a_resource()
        {
            //Arrange

            //Act
            resourceControllerSUT.Like(Resource.ID);

            //Assert
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
            Assert.True(viewModel.First().Id.EndsWith("1"), "model ID is " + viewModel.First().Id);
        }

        private void ShouldRedirectToActionDetails(ActionResult actionResult, string id)
        {
            DetailPage.AssertRedirection(actionResult, id);
        }

        private void ResourceRepositoryWillBeCalled()
        {
            _resourceService.Setup(x => x.AddResource(It.IsAny<Resource>())).Returns(_resource);
        }

        private void SetUpDefaultResourceListExpectation()
        {
            var resources = 10.CountOfResouces("tag");
            _resourceService.Setup(s => s.GetResourceList()).Returns(resources.ToList());
        }
    }
}
