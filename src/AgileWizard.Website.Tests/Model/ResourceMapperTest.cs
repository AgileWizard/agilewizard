using System.Collections.Generic;
using AgileWizard.Domain.Models;
using AgileWizard.Website.Helper;
using AgileWizard.Website.Mapper;
using AgileWizard.Website.Models;
using Xunit;

namespace AgileWizard.Website.Tests.Model
{
    public class ResourceMapperTest
    {
        private readonly ResourceMapper _resourceMapperSUT;

        public ResourceMapperTest()
        {
            _resourceMapperSUT = new ResourceMapper();
            ResourceMapper.ConfigAutoMapper();
        }

        [Fact]
        public void Resource_Mapto_ResourceDetailView()
        {
            var resource = Resource.DefaultResource();

            var resourceDetailViewModel = _resourceMapperSUT.MapFromDomainToDetailViewModel(resource);
            
            AssertUnchangedFields(resource, resourceDetailViewModel);

            Assert.Equal(resource.Id.Substring(10), resourceDetailViewModel.Id);
            Assert.Equal(resource.Tags.ToTagString(), resourceDetailViewModel.Tags);
        }

        [Fact]
        public void ResourceDetailView_Mapto_Resource()
        {
            var resourceDetailViewModel = ResourceDetailViewModel.DefaultResourceDetailViewModel();

            var resource = _resourceMapperSUT.MapFromDetailViewModelToDomain(resourceDetailViewModel);

            AssertUnchangedFields(resource, resourceDetailViewModel);

            Assert.Equal(resource.Id, string.Format("resources/{0}", resourceDetailViewModel.Id));
            Assert.Equal(resource.Tags.ToTagString(), resourceDetailViewModel.Tags);
        }

        [Fact]
        public void ResourceList_Mapto_ResourceListView()
        {
            var resourceList = new List<Resource> {Resource.DefaultResource()};

            var resourceListView = _resourceMapperSUT.MapFromDomainListToListViewModel(resourceList);

            AssertUnchangedFields(resourceList[0], resourceListView[0]);

            Assert.Equal(resourceList[0].Id.Substring(10), resourceListView[0].Id);
            Assert.Equal(Utils.ExcerptContent(resourceList[0].Content, 200), resourceListView[0].Content);
            Assert.Equal(Utils.FetchFirstImageUrl(resourceList[0].Content), resourceListView[0].ImageUrl);
        
        }

        private void AssertUnchangedFields(Resource resource, ResourceViewModel resourceViewModel)
        {
            Assert.Equal(resource.Author, resourceViewModel.Author);
            Assert.Equal(resource.SubmitUser, resourceViewModel.SubmitUser);
        }
    }
}
