using System;
using System.Collections;

using AgileWizard.AcceptanceTests.Helper;
using AgileWizard.Locale.Resources.Models;
using AgileWizard.Locale.Resources.Views;
using Xunit;
using WatiN.Core;

namespace AgileWizard.AcceptanceTests.PageObject
{
    [Page(UrlRegex = @"Resource(/Index)?$")]
    public class ResourceListPage : Page
    {
        public Link CreateResourceLink
        {
            get
            {
                return Document.Link(Find.ById("create_link"));
            }
        }

        public int TotalCount
        {
            get
            {
                string totalCount = Document.Span(Find.ById("total_count")).Text;
                return Int32.Parse(totalCount);
            }
        }

        public string PageTitle
        {
            get
            {
                return Document.Title;
            }
        }

        public void GoToResourceDetail(string title)
        {
            BrowserHelper.ClickByText(title);
        }

        public void GoToResourceEdit(string title)
        {
            var browser = BrowserHelper.Browser;
            browser.Link(l => l.Text == ResourceString.Edit.Trim() && l.Parent.NextSibling.Text == title).Click();
        }

        public void AssertTotalResourceCount()
        {
            Assert.True(this.TotalCount > 0);
        }

        public void AssertCulture()
       {
            var expect = ResourceString.Resources;
            Assert.Equal(this.PageTitle, expect);
        }

        public void AssertAddAndEditLinkNotShown()
        {
            //BrowserHelper.AssertElementByClassNameNotExist(ResourceString.CreateResourceLink, _createNewResource);
            throw new NotImplementedException();
        }
    }
}
