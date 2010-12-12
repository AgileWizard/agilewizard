using TechTalk.SpecFlow;
using AgileWizard.AcceptanceTests.Helper;
using Xunit;
using AgileWizard.Locale;

namespace AgileWizard.AcceptanceTests.Steps
{
    [Binding]
    public class Resource
    {
       #region Add resource
        [Given(@"open adding-resource page")]
        public void GivenOpenAddingResourcePage()
        {
            BrowserHelper.OpenPage("Resource/Create");
        }

        [Given(@"enter title - '([\w\s]+)' and content - '([\w\s]+)' and author - '([\w\s]+)'")]
        public void GivenEnterTitleAndContentAndAuthor(string title, string content, string author)
        {
            BrowserHelper.InputText("Title", title);
            BrowserHelper.InputText("Author", author);
            BrowserHelper.InputText("Content", content);
        }

        [Given(@"enter title - '([\w\s]+)' and content - '([\w\s]+)'")]
        public void GivenEnterTitleAndContent(string title, string content)
        {
            BrowserHelper.InputText("Title", title);
            BrowserHelper.InputText("Content", content);
        }
        #endregion

        #region Resource List
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

        [Given(@"edit a resource titled with '([\w\s]+)'")]
        public void GivenEditAResourceTitledWithEmbededVideo(string title)
        {
            var browser = BrowserHelper.Browser;
            browser.Link(l => l.Text == LocaleHelper.GetLocaleString("Edit").Trim() && l.Parent.NextSibling.Text == title).Click();
        }

        [Then(@"I can see the total resouce count")]
        public void ThenICanSeeTheTotalResouceCount()
        {
            var browser = BrowserHelper.Browser;
            Assert.True(int.Parse(browser.Element(x => x.ClassName == "totalResourceCount").Text) > 0);
        }
        #endregion 

        #region View Detail
        [Then(@"'([\w\s]+)' resource details page should be open")]
        public void ResourceDetailsPageShouldBeOpen(string title)
        {
            var browser = BrowserHelper.Browser;
            Assert.Equal(title, browser.Title);
            var head = browser.Element(e => e.ClassName == "Title");
            Assert.Equal(title, head.Text);
        }
        #endregion

        #region Resource List Culture
        [Then(@"I can see the page title in current culture")]
        public void ThenICanSeeThePageTitleinCurrentCulture()
        {
            var expect = LocaleHelper.GetLocaleString("Resources");
            Assert.Equal(BrowserHelper.Browser.Title, expect);
        }

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
            var title = LocaleHelper.GetLocaleString("Title");
            Assert.Equal(title, BrowserHelper.Browser.Element(s => s.IdOrName == "listTitle").Text.Trim());

            var content = LocaleHelper.GetLocaleString("Content");
            Assert.Equal(content, BrowserHelper.Browser.Element(s => s.IdOrName == "listContent").Text.Trim());
        }
        #endregion
    }
}
