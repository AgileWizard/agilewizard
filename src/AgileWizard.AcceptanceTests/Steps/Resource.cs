using AgileWizard.AcceptanceTests.Helper;
using AgileWizard.AcceptanceTests.PageObject;
using TechTalk.SpecFlow;

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
           ResoucePage.GoToCreate();
        }

        [Given(@"enter title - '([\w\s]+)' and content - '([\w\s]+)' and author - '([\w\s]+)' and tags - '(.+)'")]
        public void GivenEnterTitleAndContentAndAuthorAndTags(string title, string content, string author, string tags)
        {
            _resourcePage = new ResoucePage(title, author, content, tags);
        }

        [Given(@"enter title - '([\w\s]+)' and content - '([\w\s]+)' and author - '([\w\s]+)'")]
        public void GivenEnterTitleAndContentAndAuthor(string title, string content, string author)
        {
            _resourcePage = new ResoucePage(title, author, content);
        }

        [When(@"press submit button")]
        public void WhenPressSubmitButton()
        {
            ResoucePage.Submit();
        }
        #endregion

        #region View Detail
        [Then(@"resource details page should be shown")]
        public void ThenResourceDetailsPageShouldBeShown()
        {
            _resourcePage.AssertPage();
        }

        [Then(@"resource details page title with - '([\w\s]+)' should be shown")]
        public void ThenResourceDetailsPageTitleWithDetailTitleShouldBeShown(string title)
        {
            BrowserHelper.AssertPageTitle(title);
        }
        #endregion

        #region Add Resource require login
        [Then("login page should be open")]
        public void AddResource_RequireLogin_RedirectToLoginPage()
        {
            AccountPage.AssertUrl();
        }

        #endregion

        #region Resource List
        [Given(@"open resource list page")]
        public void GivenOpenResourceListPage()
        {
            ResourceListPage.GoToPage();
        }

        [When(@"open a resource titled with '([\w\s]+)'")]
        public void ClickOnATitleOfAResource(string title)
        {
            ResourceListPage.GoToResourceDetail(title);
        }

        [Given(@"edit a resource titled with '([\w\s]+)'")]
        public void GivenEditAResource(string title)
        {
            ResourceListPage.GoToResourceEdit(title);
        }

        [Then(@"I can see the total resouce count")]
        public void ThenICanSeeTheTotalResouceCount()
        {
            ResourceListPage.AssertTotalResourceCount();
        }
        #endregion

        #region Resource List Culture
        [Then(@"resoure list page should be in current culture")]
        public void ThenICanSeeThePageinCurrentCulture()
        {
            ResourceListPage.AssertCulture();
        }
   
        #endregion

    }
}
