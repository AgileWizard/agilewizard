using System.Linq;
using TechTalk.SpecFlow;
using AgileWizard.AcceptanceTests.Helper;
using Xunit;
using AgileWizard.Locale;

namespace AgileWizard.AcceptanceTests.Steps
{
    [Binding]
    public class Resource
    {
        [Given(@"open adding-resource page")]
        public void GivenOpenAddingResourcePage()
        {
            BrowserHelper.OpenPage("Resource/Create");
        }

        [Given(@"enter title - '([\w\s]+)' and content - '([\w\s]+)'")]
        public void GivenEnterTitleAndContent(string title, string content)
        {
            BrowserHelper.InputText("Title", title);
            BrowserHelper.InputText("Content", content);
        }

        [Then(@"should be redirected to list page")]
        public void ThenShouldBeRedirectedToListPage()
        {
            var browser = BrowserHelper.Browser;
            var suffix = "Resource";

            Assert.Equal(BrowserHelper.WebsiteUrl + suffix, browser.Url);
        }

        [Given(@"open resource list page")]
        public void GivenOpenResourceListPage()
        {
            BrowserHelper.OpenPage("Resource");
        }

        [When(@"open a resource titled with '([\w\s]+)'")]
        public void ClickOnATitleOfAResource(string title)
        {
            var browser = BrowserHelper.Browser;
            browser.Link(l => l.Text == title).Click();
        }

        [Then(@"'([\w\s]+)' resource details page should be open")]
        public void ResourceDetailsPageShouldBeOpen(string title)
        {
            var browser = BrowserHelper.Browser;
            Assert.Equal(title, browser.Title);
            var head = browser.Element(e => e.ClassName == "Title");
            Assert.Equal(title, head.Text);
        }
        
        [Then(@"I can see the total resouce count")]
        public void ThenICanSeeTheTotalResouceCount()
        {
            var browser = BrowserHelper.Browser;
            Assert.True(int.Parse(browser.Element(x => x.ClassName == "totalResourceCount").Text) > 0);
        }

        #region Resource List Culture
        [Then(@"I can see the create resource entry in current culture")]
        public void ThenICanSeeTheCreateResourceEntryInCurrentCulture()
        {
            var expect = LocaleHelper.GetLocaleString("Create New Resource");
            Assert.Equal(BrowserHelper.Browser.Element(x => x.ClassName == "createNewResource").Text, expect);
        }

        [Then(@"I can see the total resource count in current culture")]
        public void ThenICanSeeTheTotalResourceCountInCurrentCulture()
        {
            var expect = LocaleHelper.GetLocaleString("Total resource count:");
            Assert.Equal(BrowserHelper.Browser.Element(x => x.ClassName == "display-label").Text, expect);
        }

        [Then(@"I can see the List in current culture")]
        public void ThenICanSeeTheListInCurrentCulture()
        {
          //toto
        }
        #endregion
    }
}
