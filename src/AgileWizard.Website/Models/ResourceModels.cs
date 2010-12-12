using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;
using AgileWizard.Locale;
using AgileWizard.Locale.Resources.Models;

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
    }

    public class ResourceList : List<ResourceModel>
    {
        public int TotalCount { set; get; }

    }
}