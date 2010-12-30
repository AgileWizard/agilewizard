using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileWizard.AcceptanceTests.Helper;
using System.Text.RegularExpressions;

namespace AgileWizard.AcceptanceTests.PageObject
{
    public class ResourceDetailsPage : IDisposable
    {
        public string Title
        {
            get
            {
                return BrowserHelper.Browser.Title;
            }
        }

        public string Author
        {
            get
            {
                return BrowserHelper.Browser.Span(x => x.ClassName == "Author").Text;
            }
        }

        public string Content
        {
            get
            {
                return BrowserHelper.Browser.Div(x => x.ClassName == "Content").Text;
            }
        }

        public string ReferenceUrl
        {
            get
            {
                return BrowserHelper.Browser.Span(x => x.ClassName == "ReferenceUrl").Text;
            }
        }

        public string Tags
        {
            get
            {
                return BrowserHelper.Browser.Span(x => x.ClassName == "Tags").Text;
            }
        }

        public bool IsCurrentPage()
        {
            var regex = new Regex(@".+/Resource/Details/\d+");

            return regex.IsMatch(BrowserHelper.Browser.Url);
        }

        public void Dispose()
        {
        }
    }
}
