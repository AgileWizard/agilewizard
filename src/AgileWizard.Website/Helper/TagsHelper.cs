using System;
using System.Collections.Generic;
using System.Linq;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.Services;

namespace AgileWizard.Website.Helper
{
    public static class TagsHelper
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

        public static string ToTagString(this List<Resource.ResourceTag> tags)
        {
            if (tags == null)
                return string.Empty;

            var tagNames = tags.Select(s => s.Name)
                .Distinct(StringComparer.OrdinalIgnoreCase);
            return string.Join(",", tagNames);
        }

        public static List<Tag> GetTagList(int maxCount)
        {
            return ServiceGateway.TagService.GetTagList(maxCount);
        }
    }
}