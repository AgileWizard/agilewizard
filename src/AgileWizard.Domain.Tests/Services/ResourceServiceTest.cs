using System;
using AgileWizard.Domain.Expression;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Services;
using Moq;
using Xunit;

namespace AgileWizard.Domain.Tests.Services
{
    public class ResourceServiceTest
    {
        private Mock<IResourceRepository> _repository;
        private IResourceService _service;

        private readonly DateTime _prepareTime = DateTime.Now.AddSeconds(-1);
        private Resource _resource = Resource.DefaultResource();

        public ResourceServiceTest()
        {
            _repository = new Mock<IResourceRepository>();
            _service = new ResourceService(_repository.Object);

            _resource.CreateTime = _prepareTime;
            _resource.LastUpdateTime = _prepareTime;
        }

        #region CRUD
        [Fact]
        public void Can_add_resource()
        {
            //Arrange
            _repository.Setup(r => r.Add(_resource)).Returns(_resource);

            //Act
            var actualResource = _service.AddResource(_resource);

            //Assert
            _repository.Verify(r => r.Add(_resource));
            _repository.Verify(r => r.Save());
            Assert.Equal(_resource, actualResource);
        }

        [Fact]
        public void Given_an_id_should_return_a_resource()
        {
            //Arrange
            SetGetResourceByIDReturnDefaultResource();

            //Act
            var actualResource = _service.GetResourceById(Resource.ID);

            //Assert
            Assert.Equal(_resource, actualResource);
        }

        [Fact]
        public void Get_ListOf_Resources()
        {
            // Arrange
            var expectedResources = 10.CountOfResouces("tag");
            _repository.Setup(r => r.GetList(It.IsAny<ResourceListQueryExpression>())).Returns(expectedResources);

            // Act
            var actualResources = _service.GetResourceList(DateTime.Now.Ticks);

            // Assert
            _repository.Verify(r => r.GetList(It.IsAny<ResourceListQueryExpression>()));
            Assert.Equal(expectedResources, actualResources);
        }

        [Fact]
        public void Can_update_resource()
        {
            //Arrange
            var resourceToUpdate = new Resource { Title = "Title to update", Content = "Content to update" };
            SetGetResourceByIDReturnDefaultResource();

            //Act
            _service.UpdateResource(Resource.ID, resourceToUpdate);

            //Assert
            _repository.Verify(r => r.Save());

            ResourceShouldBeUpdated(_resource, resourceToUpdate);
        } 
        #endregion

        #region Like/Dislike/PageView
        [Fact]
        public void When_get_a_resource_should_increment_page_view()
        {
            //Arrange
            const int pageView = 1;
            _resource.PageView = pageView;

            SetGetResourceByIDReturnDefaultResource();

            //Act
            var actualResource = _service.GetResourceById(Resource.ID);

            //Assert
            Assert.Equal(pageView + 1, actualResource.PageView);
        }

        [Fact]
        public void When_get_a_resource_should_save_incremented_page_view()
        {
            //Arrange
            SetGetResourceByIDReturnDefaultResource();

            //Act
            _service.GetResourceById(Resource.ID);

            //Assert
            _repository.Verify(r => r.Save());
        }

        [Fact]
        public void When_like_a_resource_increment_like_number()
        {
            //Arrange
            const int like = 1;
            _resource.Like = like;
            SetGetResourceByIDReturnDefaultResource();

            //Act
            _service.LikeThisResource(Resource.ID);

            //Assert
            Assert.Equal(like + 1, _resource.Like);
        }

        [Fact]
        public void When_like_a_resource_incremented_like_number_should_be_saved()
        {
            //Arrange
            SetGetResourceByIDReturnDefaultResource();

            //Act
            _service.LikeThisResource(Resource.ID);

            //Assert
            _repository.Verify(r => r.Save());
        }

        [Fact]
        public void When_dislike_a_resource_increment_dislike_number()
        {
            //Arrange
            const int dislike = 1;
            _resource.Dislike = dislike;
            SetGetResourceByIDReturnDefaultResource();

            //Act
            _service.DislikeThisResource(Resource.ID);

            //Assert
            Assert.Equal(dislike + 1, _resource.Dislike);
        }

        [Fact]
        public void When_dislike_a_resource_incremented_dislike_number_should_be_saved()
        {
            //Arrange
            SetGetResourceByIDReturnDefaultResource();

            //Act
            _service.DislikeThisResource(Resource.ID);

            //Assert
            _repository.Verify(r => r.Save());
        }

        #endregion

        #region Tag
        [Fact]
        public void should_return_resource_by_given_tag()
        {
            var expectedResources = 10.CountOfResouces("tag");
            _repository.Setup(r => r.GetList(It.IsAny<TagResourceListQueryExperssion>())).Returns(expectedResources);

            var actualResources = _service.GetResourceListByTag(DateTime.Now.Ticks, "tag");

            _repository.Verify(r => r.GetList(It.IsAny<TagResourceListQueryExperssion>()));
            Assert.Equal(expectedResources, actualResources);
        }
        #endregion


        #region Resource recommendation list
        [Fact]
        public void ShouldReturn_LikeList()
        {
            var expectedResources = 3.CountOfResouces("tag");
            _repository.Setup(r => r.GetList(It.IsAny<TopLikeResourceListQueryExperssion>())).Returns(expectedResources);

            var actualResources = _service.GetLikeList();

            _repository.Verify(r => r.GetList(It.IsAny<TopLikeResourceListQueryExperssion>()));
            Assert.Equal(expectedResources, actualResources);
        } 
        #endregion

        #region Private functions
        private void ResourceShouldBeUpdated(Resource resource, Resource resourceToUpdate)
        {
            Assert.Equal(resourceToUpdate.Title, resource.Title);
            Assert.Equal(resourceToUpdate.Content, resource.Content);
            Assert.Equal(_prepareTime, resource.CreateTime);
            Assert.True(resource.LastUpdateTime > _prepareTime);
        }

        private void SetGetResourceByIDReturnDefaultResource()
        {
            _repository.Setup(r => r.GetResourceById(Resource.ID)).Returns(_resource);
        } 
        #endregion
    }

   
}
