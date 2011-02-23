using System.Collections.Generic;
using AgileWizard.Domain.Models;

namespace AgileWizard.Domain.Helper
{
    public static class TagHelper
    {
        private static readonly char[] COMMA = { ',', '，' };
        public static List<Resource.ResourceTag> ToTagList(this string tags)
        {
            var tagList = new List<Resource.ResourceTag>();
            if (string.IsNullOrEmpty(tags)) return tagList;

            var tagNames = tags.Split(COMMA);
            foreach (var name in tagNames)
            {
                tagList.Add(new Resource.ResourceTag { Name = name.Trim() });
            }

            return tagList;
        }
    }
}
