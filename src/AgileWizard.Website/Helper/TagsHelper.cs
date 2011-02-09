using System;
using System.Collections.Generic;
using System.Linq;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.Services;

namespace AgileWizard.Website.Helper
{
    public static class TagsHelper
    {
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