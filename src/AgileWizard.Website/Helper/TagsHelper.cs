using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgileWizard.Domain.Models;
using System.Text;

namespace AgileWizard.Website.Helper
{
    public static class TagsHelper
    {
        private static readonly char[] COMMA = { ',', '，' };
        public static List<Tag> ToTagList(this string tags)
        {
            var tagList = new List<Tag>();
            if (string.IsNullOrEmpty(tags)) return tagList;

            var tagNames = tags.Split(COMMA);
            foreach (var name in tagNames)
            {
                tagList.Add(new Tag { Name = name.Trim() });
            }

            return tagList;
        }

        public static string ToTagString(this List<Tag> tags)
        {
            if (tags == null)
                return string.Empty;

            var tagNames = tags.Select<Tag, string>(s => s.Name)
                .Distinct(StringComparer.OrdinalIgnoreCase); ;
            return string.Join(",", tagNames);
        }
    }
}