using System;
using System.Collections.Generic;
using AgileWizard.Domain.Helper;

namespace AgileWizard.Domain.Models
{
    public class Resource
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }
       
        public string ReferenceUrl { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastUpdateTime { get; set; }

        public string SubmitUser { get; set; }

        public List<ResourceTag> Tags { get; set; }

        public int PageView { get; set; }

        public int Like { get; set; }

        public int Dislike { get; set; }

        public class ResourceTag
        {
            public string Name { get; set; }
        }

        #region Test Utility Methods

        internal const string ID = "1";
        private const string DOCUMENT_ID = "resources/1";
        private const string TITLE = "title";
        private const string CONTENT = "content";
        private const string AUTHOR = "author";
        private const string SUBMITUSER = "submitUser";
        private const string REFERENCE_URL = "http://www.cnblogs.com/tengzy/";
        
        internal static Resource DefaultResource()
        {
            return new Resource
            {
                Id = DOCUMENT_ID,
                Title = TITLE,
                Content = CONTENT,
                Author = AUTHOR,
                ReferenceUrl = REFERENCE_URL,
                SubmitUser = SUBMITUSER,
                Tags = "TDD,Shanghai".ToTagList()
            };
        }
        #endregion
    }
}
