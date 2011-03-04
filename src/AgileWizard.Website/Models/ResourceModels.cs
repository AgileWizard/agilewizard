using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using AgileWizard.Domain.Models;
using AgileWizard.Locale;
using AgileWizard.Locale.Resources.Models;
using AgileWizard.Website.Mapper;

namespace AgileWizard.Website.Models
{

    public class ResourceViewModel
    {
        [LocalizedDisplayName("Id", NameResourceType = typeof(ResourceName))]
        public string Id { get; set; }

        [LocalizedRequiredAttribute]
        [LocalizedDisplayName("Title", NameResourceType = typeof(ResourceName))]
        public string Title { get; set; }

        [LocalizedRequiredAttribute]
        [LocalizedDisplayName("Content", NameResourceType = typeof(ResourceName))]
        public string Content { get; set; }

        [LocalizedDisplayName("CreateTime", NameResourceType = typeof(ResourceName))]
        public DateTime CreateTime { get; set; }

        [LocalizedDisplayName("Author", NameResourceType = typeof(ResourceName))]
        public string Author { get; set; }

        [LocalizedDisplayName("SubmitUser", NameResourceType = typeof(ResourceName))]
        public string SubmitUser { get; set; }

        public int PageView { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
    }

    public class ResourceDetailViewModel : ResourceViewModel
    {
        [LocalizedDisplayName("Tags", NameResourceType = typeof(ResourceName))]
        public string Tags { get; set; }

        [LocalizedDisplayName("ReferenceUrl", NameResourceType = typeof(ResourceName))]
        [RegularExpression(@"\b(\w*)://[-A-z0-9+&@#/%?=~_|!:,.;]*[-A-z0-9+&@#/%=~_|]")]
        public string ReferenceUrl { get; set; }

        public ResourceDetailViewModel()
        {
        }

        #region Test Utility Methods
        internal ResourceDetailViewModel(Resource resource)
        {
            ResourceMapper.MapFromDomainToDetailViewModel(resource);
        }
        #endregion
    }

    public class ResourceListViewModel : ResourceViewModel
    {
        [LocalizedDisplayName("Tags", NameResourceType = typeof(ResourceName))]
        public List<Resource.ResourceTag> Tags { get; set; }

        public string ImageUrl { get; set; }
    }


    public class ResourceList : List<ResourceListViewModel>
    {
        public int CurrentPage { get; set; }

        public ResourceList(IList<Resource> resources, int currentPage)
        {
            ResourceMapper.MapFromDomainListToListViewModel(resources, this);
            CurrentPage = currentPage;
        }
    }
}