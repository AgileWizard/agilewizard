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

        [Given(@"enter title - '([\w\s]+)' and content - '([\w\s]+)' and author - '([\w\s]+)'")]
        public void GivenEnterTitleAndContentAndAuthor(string title, string content, string author)
        {
            BrowserHelper.InputText("Title", title);
            BrowserHelper.InputText("Content", content);
            BrowserHelper.InputText("Author", author);
        }

        [Given(@"enter title - '([\w\s]+)' and content - '([\w\s]+)'")]
        public void GivenEnterTitleAndContent(string title, string content)
        {
            BrowserHelper.InputText("Title", title);
            BrowserHelper.InputText("Content", content);
        }

        [Then(@"should be redirected to details page")]
        public void ThenShouldBeRedirectedToDetailsPage()
        {
            var browser = BrowserHelper.Browser;
            var suffix = "Resource/Details";
            Assert.True(browser.Url.StartsWith(BrowserHelper.WebsiteUrl + suffix));
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

        [Given(@"edit a resource titled with '([\w\s]+)'")]
        public void GivenEditAResourceTitledWithEmbededVideo(string title)
        {
            var browser = BrowserHelper.Browser;
            browser.Link(l => l.Text == "编辑" && l.Parent.NextSibling.Text == title).Click();
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
