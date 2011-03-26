using System;
using AgileWizard.Domain.Helper;
using AgileWizard.Domain.Models;

namespace AgileWizard.Data
{
    public class ResourceBuilder
    {
        internal const string ID = "1";
        private const string TITLE = "title";
        private const string CONTENT = "content";
        private const string AUTHOR = "author";
        private const string SUBMITUSER = "submitUser";
        private const string REFERENCE_URL = "http://www.danielteng.com";
        private const string idPrefix = "ID00000000";

        private DateTime _createTime;
        private string _tagName = "tag";

        public static ResourceBuilder AnResource()
        {
            return new ResourceBuilder();
        }

        public Resource Build(int i)
        {
            return  new Resource
                       {
                           Id = idPrefix + i,
                           Title = TITLE,
                           Content = CONTENT,
                           Author = AUTHOR,
                           ReferenceUrl = REFERENCE_URL,
                           SubmitUser = SUBMITUSER,
                           Tags = _tagName.ToTagList(),
                           CreateTime = _createTime,
                           LastUpdateTime = _createTime,
            };
        }

        public ResourceBuilder WithCreateUpdateTime(int minsBefore)
        {
            _createTime = DateTime.Now.AddMinutes(-minsBefore);
            return this;
        }

        public ResourceBuilder WithTag(string tagName)
        {
            _tagName = tagName;
            return this;
        }
    }
}
