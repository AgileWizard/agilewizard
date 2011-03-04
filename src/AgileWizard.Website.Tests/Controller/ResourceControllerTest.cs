using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.Users;
using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Services;
using AgileWizard.Website.Controllers;
using AgileWizard.Website.Mapper;
using AgileWizard.Website.Models;
using AgileWizard.Website.Tests.Helper;
using AgileWizard.Website.Tests.PageObject;
using Moq;
using Raven.Client;
using Xunit;

namespace AgileWizard.Website.Tests.Controller
{
    public class ResourceControllerTest
    {
        #region Fields
        private readonly Mock<IResourceService> _resourceService;
        private readonly Mock<IDocumentSession> _documentSession;
        private readonly Mock<ISessionStateRepository> _sessionStateRepository;

        private readonly ResourceController resourceControllerSUT;
        private readonly Resource _resource = Resource.DefaultResource();
        private readonly ResourceDetailViewModel _resourceDetailViewModel = ResourceModelTestHelper.BuildDefaultResourceDetailViewModel();
        #endregion

        public ResourceControllerTest()
        {
            _resourceService = new Mock<IResourceService>();
            _documentSession = new Mock<IDocumentSession>();
            _sessionStateRepository = new Mock<ISessionStateRepository>();

            ResourceMapper.ConfigAutoMapper();

            resourceControllerSUT = new ResourceController(_resourceService.Object, _documentSession.Object, _sessionStateRepository.Object);
        }

        #region CRUD
        [Fact]
        public void when_add_resource()
        {
            //Arrange
            WithDefaultUser();

            ResourceRepositoryWillBeCalled();

            //Act
            var actionResult = resourceControllerSUT.Create(_resourceDetailViewModel);

            //Assert
            _resourceService.Verify(x => x.AddResource(It.IsAny<Resource>()));
            ShouldRedirectToActionDetails(actionResult, Resource.ID);
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
            SetGetResourceByIDReturnDefaultResourceExpectation();

            //Act
            var actionResult = resourceControllerSUT.Details(Resource.ID);

            //Assert
            ShouldShowDefaultViewWithModel(_resource.Title, actionResult);
        }

        [Fact]
        public void edit_action_should_return_a_view_for_a_resource()
        {
            //Arrange
            SetGetResourceByIDReturnDefaultResourceExpectation();

            //Act
            var actionResult = resourceControllerSUT.Edit(Resource.ID);

            //Assert
            ShouldShowDefaultViewWithModel(_resource.Title, actionResult);
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
        public void show_list_with_paging()
        {
            //Arrange
            SetUpDefaultResourceListExpectation();
            const int currentPage = 0;

            //Act
            var actionResult = resourceControllerSUT.ResourceList(currentPage);

            //Assert
            ShouldShowResourceListUserControlWithModel(actionResult);
        }
        #endregion

        #region Tag
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
        #endregion

        #region Like/Dislike
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
        #endregion

        #region Private functions
        private void ShouldShowResourceListUserControlWithModel(ActionResult actionResult)
        {
            var partialViewResult = AssertPartialViewResult(actionResult);

            AssertResourceListOfViewModel(partialViewResult);
        }

        private void ShouldShowDefaultViewWithModel(string title, ActionResult actionResult)
        {
            var viewResult = AssertViewResult(actionResult);

            AssertResourceViewModel(viewResult, title);
        }

        private void ShouldShowIndexViewWithModel(ActionResult actionResult)
        {
            var viewResult = AssertViewResult(actionResult);

            AssertResourceListOfViewModel(viewResult);
        }

        private ViewResultBase AssertViewResult(ActionResult actionResult)
        {
            Assert.IsType<ViewResult>(actionResult);
            var viewResult = (ViewResultBase)actionResult;
            AssertViewName(string.Empty, viewResult);
            return viewResult;
        }

        private void AssertViewName(string viewName, ViewResultBase viewResultBase)
        {
            Assert.Equal(viewName, viewResultBase.ViewName);
        }

        private ViewResultBase AssertPartialViewResult(ActionResult actionResult)
        {
            Assert.IsType<PartialViewResult>(actionResult);
            var partialViewResult = (ViewResultBase)actionResult;
            AssertViewName("ResourceList", partialViewResult);
            return partialViewResult;
        }

        private void AssertResourceListOfViewModel(ViewResultBase partialViewResult)
        {
            var viewModel = (IEnumerable<ResourceListViewModel>)partialViewResult.ViewData.Model;
            Assert.True(viewModel.First().Id.EndsWith("1"), "model ID is " + viewModel.First().Id);
        }

        private void AssertResourceViewModel(ViewResultBase viewResult, string title)
        {
            var viewModel = (ResourceDetailViewModel)viewResult.ViewData.Model;
            Assert.Equal(title, viewModel.Title);
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
            const int firstPage = 0;
            _resourceService.Setup(s => s.GetResourceList(firstPage)).Returns(resources.ToList());
        }

        private void WithDefaultUser()
        {
            _sessionStateRepository.Setup(s => s.CurrentUser).Returns(User.DefaultUser());
        }

        private void SetGetResourceByIDReturnDefaultResourceExpectation()
        {
            _resourceService.Setup(s => s.GetResourceById(Resource.ID)).Returns(_resource);
        } 
        #endregion
    }
}
