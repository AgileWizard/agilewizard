using System;
using AgileWizard.AcceptanceTests.Helper;
using AgileWizard.Locale.Resources.Models;
using AgileWizard.Locale.Resources.Views;
using Xunit;

namespace AgileWizard.AcceptanceTests.PageObject
{
    public class ResourceListPage : WatiN.Core.Page, IDisposable
    {
        private const string Url = "Resource";
        private const string _listContent = "listContent";
        private const string _listTitle = "listTitle";
        private const string _displayLabel = "display-label";
        private const string _createNewResource = "link";
        private const string _totalResourceCount = "totalResourceCount";

        public void GoToPage()
        {
            BrowserHelper.OpenPage(Url);
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
            var totalResoureCount = int.Parse(BrowserHelper.GetElementTextByClassName(_totalResourceCount)); 
            Assert.True(totalResoureCount > 0);
        }

        public void AssertCulture()
        {
            var expect = ResourceString.Resources;
            Assert.Equal(BrowserHelper.Browser.Title, expect);

            BrowserHelper.AssertElementByClassName(ResourceString.CreateResourceLink, _createNewResource);

            BrowserHelper.AssertElementByClassName(ResourceString.TotalResourceCount, _displayLabel);

            BrowserHelper.AssertElementByIDOrName(ResourceName.Title, _listTitle);

            BrowserHelper.AssertElementByIDOrName(ResourceName.Content, _listContent);
        }

        public void AssertAddAndEditLinkNotShown()
        {
            BrowserHelper.AssertElementByClassNameNotExist(ResourceString.CreateResourceLink, _createNewResource);
        }

        #region IDisposable Members

        public void Dispose()
        {
        }

        #endregion
    }
}
