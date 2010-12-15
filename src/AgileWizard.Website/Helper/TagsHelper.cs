using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgileWizard.Domain.Resources;
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
                tagList.Add(new Tag { Name = name });
            }

            return tagList;
        }

        public static string ToTagString(this List<Tag> tags)
        {
            if(tags == null)
                return string.Empty;
            var sb = new StringBuilder();
            tags.ForEach(x => sb.AppendFormat("{0} ", x.Name));
            if(sb.Length > 0)
                sb = sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
    }
}