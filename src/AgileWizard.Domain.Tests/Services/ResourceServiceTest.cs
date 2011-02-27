using System;
using System.Collections.Generic;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Services;
using Moq;
using Xunit;

namespace AgileWizard.Domain.Tests.Services
{
    public class ResourceServiceTest
    {
        private const string ID = "1";
        private const string DOCUMENT_ID = "resources/1";
        private const string TITLE = "title";
        private const string CONTENT = "content";
        private const string AUTHOR = "author";
        private const string SUBMITUSER = "submituser";

        private Mock<IResourceRepository> _repository;
        private IResourceService _service;

        private readonly DateTime _prepareTime = DateTime.Now.AddSeconds(-1);
        private Resource _resource = new Resource()
                                                  {
                                                      Id = DOCUMENT_ID,
                                                      Title = TITLE,
                                                      Content = CONTENT,
                                                      Author = AUTHOR,
                                                      SubmitUser = SUBMITUSER
                                                  };

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
            var resource = new Resource();
            //Arrange
            _repository.Setup(r => r.Add(resource)).Returns(_resource);

            //Act
            var actualResource = _service.AddResource(resource);

            //Assert
            _repository.Verify(r => r.Add(resource));
            _repository.Verify(r => r.Save());
            Assert.Equal(_resource, actualResource);
        }

        [Fact]
        public void Given_an_id_should_return_a_resource()
        {
            //Arrange
            var resource = Resource.DefaultResource();
            _repository.Setup(r => r.GetResourceById(ID)).Returns(resource);

            //Act
            var actualResource = _service.GetResourceById(ID);

            //Assert
            Assert.Equal(resource, actualResource);
        }

        [Fact]
        public void Can_get_a_list_of_resources()
        {
            //Arrange
            var expectedResources = new List<Resource>();
            _repository.Setup(r => r.GetResourceList()).Returns(expectedResources);

            //Act
            var actualResources = _service.GetResourceList();

            //Assert
            Assert.Equal(expectedResources, actualResources);
        }

        [Fact]
        public void Can_update_resource()
        {
            //Arrange
            var resourceToUpdate = new Resource() { Title = "Title to update", Content = "Content to update" };
            _repository.Setup(r => r.GetResourceById(ID)).Returns(_resource);

            //Act
            _service.UpdateResource(ID, resourceToUpdate);

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
            var resource = Resource.DefaultResource();
            const int pageView = 1;
            resource.PageView = pageView;
            _repository.Setup(r => r.GetResourceById(ID)).Returns(resource);

            //Act
            var actualResource = _service.GetResourceById(ID);

            //Assert
            Assert.Equal(pageView + 1, actualResource.PageView);
        }

        [Fact]
        public void When_get_a_resource_should_save_incremented_page_view()
        {
            //Arrange
            _repository.Setup(r => r.GetResourceById(ID)).Returns(Resource.DefaultResource);

            //Act
            _service.GetResourceById(ID);

            //Assert
            _repository.Verify(r => r.Save());
        }

        [Fact]
        public void When_like_a_resource_increment_like_number()
        {
            //Arrange
            var resource = Resource.DefaultResource();
            const int like = 1;
            resource.Like = like;
            _repository.Setup(r => r.GetResourceById(ID)).Returns(resource);

            //Act
            _service.LikeThisResource(ID);

            //Assert
            Assert.Equal(like + 1, resource.Like);
        }

        [Fact]
        public void When_like_a_resource_incremented_like_number_should_be_saved()
        {
            //Arrange
            _repository.Setup(r => r.GetResourceById(ID)).Returns(Resource.DefaultResource());

            //Act
            _service.LikeThisResource(ID);

            //Assert
            _repository.Verify(r => r.Save());
        }

        [Fact]
        public void When_dislike_a_resource_increment_dislike_number()
        {
            //Arrange
            var resource = Resource.DefaultResource();
            const int dislike = 1;
            resource.Dislike = dislike;
            _repository.Setup(r => r.GetResourceById(ID)).Returns(resource);

            //Act
            _service.DislikeThisResource(ID);

            //Assert
            Assert.Equal(dislike + 1, resource.Dislike);
        }

        [Fact]
        public void When_dislike_a_resource_incremented_dislike_number_should_be_saved()
        {
            //Arrange
            _repository.Setup(r => r.GetResourceById(ID)).Returns(Resource.DefaultResource());

            //Act
            _service.DislikeThisResource(ID);

            //Assert
            _repository.Verify(r => r.Save());
        }

        #endregion
        [Fact]
        public void should_return_resource_by_given_tag()
        {
            // Arrange
            var expectedResources = new List<Resource>();
            _repository.Setup(r => r.GetResourceListByTag("agile")).Returns(expectedResources);

            // Act
            var result = _service.GetResourceListByTag("agile");

            // Assert
            Assert.Same(expectedResources, result);
        }

        private void ResourceShouldBeUpdated(Resource resource, Resource resourceToUpdate)
        {
            Assert.Equal(resourceToUpdate.Title, resource.Title);
            Assert.Equal(resourceToUpdate.Content, resource.Content);
            Assert.Equal(_prepareTime, resource.CreateTime);
            Assert.True(resource.LastUpdateTime > _prepareTime);
        }
    }
}
