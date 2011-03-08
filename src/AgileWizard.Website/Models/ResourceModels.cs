using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using AgileWizard.Domain.Helper;
using AgileWizard.Domain.Models;
using AgileWizard.Locale;
using AgileWizard.Locale.Resources.Models;

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

        #region Test Utility Methods

        internal const string ID = "1";
        private const string DOCUMENT_ID = "resources/1";
        private const string TITLE = "title";
        private const string CONTENT = "content";
        private const string AUTHOR = "author";
        private const string SUBMITUSER = "submitUser";
        private const string REFERENCE_URL = "http://www.cnblogs.com/tengzy/";
        
        internal static ResourceDetailViewModel DefaultResourceDetailViewModel()
        {
            return new ResourceDetailViewModel
                       {
                           Id = DOCUMENT_ID,
                           Title = TITLE,
                           Content = CONTENT,
                           Author = AUTHOR,
                           ReferenceUrl = REFERENCE_URL,
                           SubmitUser = SUBMITUSER,
                           Tags = "TDD,Shanghai"
                       };
        }
        #endregion
    }

    public class ResourceListViewModel : ResourceViewModel
    {
        [LocalizedDisplayName("Tags", NameResourceType = typeof(ResourceName))]
        public List<Resource.ResourceTag> Tags { get; set; }

        public string ImageUrl { get; set; }
    }
}