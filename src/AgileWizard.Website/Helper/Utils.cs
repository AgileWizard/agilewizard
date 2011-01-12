using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace AgileWizard.Website.Helper
{
    public static class Utils
    {
        public static readonly Regex RegexStripHtml = new Regex("<[^>]*>", RegexOptions.Compiled);
        public static readonly Regex RegexImgSrc = new Regex("<img[^>]*src=\"(.*?)\"[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public static string ExcerptContent(string content, int length)
        {
            var stripHtml = StripHtml(content);
            var actualLength = Math.Min(stripHtml.Length, length);
            return stripHtml.Substring(0, actualLength);
        }

        public static string StripHtml(string content)
        {
            return string.IsNullOrWhiteSpace(content) ? string.Empty : RegexStripHtml.Replace(content, string.Empty).Trim();
        }

        public static string FetchFirstImageUrl(string content)
        {
            var matchResult = RegexImgSrc.Match(content);
            if (matchResult.Success)
            {
                return matchResult.Groups[1].Captures[0].Value;
            }
            return null;
        }
    }
}