using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;
using AgileWizard.Domain.Models;
using AgileWizard.Locale;
using AgileWizard.Locale.Resources.Models;
using AutoMapper;

namespace AgileWizard.Website.Models
{
    public class ResourceModel
    {
        [LocalizedDisplayName("Id", NameResourceType=typeof(ResourceName))]
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

        [LocalizedDisplayName("Tags", NameResourceType = typeof(ResourceName))]
        public string Tags { get; set; }

        [LocalizedDisplayName("ReferenceUrl", NameResourceType = typeof(ResourceName))]
        [RegularExpression(@"\b(\w*)://[-A-z0-9+&@#/%?=~_|!:,.;]*[-A-z0-9+&@#/%=~_|]")]
        public string ReferenceUrl { get; set; }

        public int PageView { get; set; }
    }

    public class ResourceListViewModel
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

        [LocalizedDisplayName("Tags", NameResourceType = typeof(ResourceName))]
        public List<Resource.ResourceTag> Tags { get; set; }

        public string ImageUrl { get; set; }

        public int PageView { get; set; }
    }


    public class ResourceList : List<ResourceListViewModel>
    {
        public ResourceList(IList<Resource> resources)
        {
            Mapper.Map<IList<Resource>, IList<ResourceListViewModel>>(resources, this);
        }

        public int TotalCount { set; get; }

    }
}