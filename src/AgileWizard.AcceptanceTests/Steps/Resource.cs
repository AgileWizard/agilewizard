using AgileWizard.AcceptanceTests.PageObject;
using TechTalk.SpecFlow;
using AgileWizard.AcceptanceTests.Helper;
using Xunit;
using AgileWizard.Locale.Resources.Views;
using AgileWizard.Locale.Resources.Models;

namespace AgileWizard.AcceptanceTests.Steps
{
  
    [Binding]
    public class Resource
    {
        private ResoucePage _resourcePage;

        #region Add resource
        [Given(@"open adding-resource page")]
        public void GivenOpenAddingResourcePage()
        {
            BrowserHelper.OpenPage("Resource/Create");
        }

        [Given(@"enter title - '([\w\s]+)' and content - '([\w\s]+)' and author - '([\w\s]+)'")]
        public void GivenEnterTitleAndContentAndAuthor(string title, string content, string author)
        {
            _resourcePage = new ResoucePage(title, author, content);
        }

        [When(@"press submit button")]
        public void WhenPressSubmitButton()
        {
            BrowserHelper.PressSubmitButton();
        }
        #endregion

        #region View Detail
        [Then(@"resource details page should be shown")]
        public void ThenResourceDetailsPageShouldBeShown()
        {
            _resourcePage.AssertPage();
        }
        #endregion

        #region Add Resource require login
        [Then("login page should be open")]
        public void AddResource_RequireLogin_RedirectToLoginPage()
        {
            var currentUrl = BrowserHelper.Browser.Url;
            var expect = "Account/Logon";
            Assert.True(currentUrl.EndsWith(expect));
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
        public void GivenEditAResource(string title)
        {
            var browser = BrowserHelper.Browser;
            browser.Link(l => l.Text == ResourceString.Edit.Trim() && l.Parent.NextSibling.Text == title).Click();
        }

        [Then(@"I can see the total resouce count")]
        public void ThenICanSeeTheTotalResouceCount()
        {
            var browser = BrowserHelper.Browser;
            Assert.True(int.Parse(browser.Element(x => x.ClassName == "totalResourceCount").Text) > 0);
        }
        #endregion

        #region Resource List Culture
        [Then(@"I can see the page title in current culture")]
        public void ThenICanSeeThePageTitleinCurrentCulture()
        {
            var expect = ResourceString.Resources;
            Assert.Equal(BrowserHelper.Browser.Title, expect);
        }

        [Then(@"I can see the create resource entry in current culture")]
        public void ThenICanSeeTheCreateResourceEntryInCurrentCulture()
        {
            var expect = ResourceString.CreateResourceLink;
            Assert.Equal(BrowserHelper.Browser.Element(x => x.ClassName == "createNewResource").Text, expect);
        }

        [Then(@"I can see the total resource count in current culture")]
        public void ThenICanSeeTheTotalResourceCountInCurrentCulture()
        {
            var expect = ResourceString.TotalResourceCount;
            Assert.Equal(BrowserHelper.Browser.Element(x => x.ClassName == "display-label").Text, expect);
        }

        [Then(@"I can see the List in current culture")]
        public void ThenICanSeeTheListInCurrentCulture()
        {
            var title = ResourceName.Title;
            Assert.Equal(title, BrowserHelper.Browser.Element(s => s.IdOrName == "listTitle").Text.Trim());

            var content = ResourceName.Content;
            Assert.Equal(content, BrowserHelper.Browser.Element(s => s.IdOrName == "listContent").Text.Trim());
        }
        #endregion

    }
}
