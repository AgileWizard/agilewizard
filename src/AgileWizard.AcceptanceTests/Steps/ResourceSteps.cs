using AgileWizard.AcceptanceTests.Helper;
using AgileWizard.AcceptanceTests.PageObject;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using AgileWizard.AcceptanceTests.Data;

namespace AgileWizard.AcceptanceTests.Steps
{
  
    [Binding]
    public class ResourceSteps
    {
        private ResourcePage _resourcePage;

        #region Add resource
        [Given(@"open adding-resource page")]
        public void GivenOpenAddingResourcePage()
        {
           ResourcePage.GoToCreate();
        }

        [Given(@"enter data in resource page")]
        public void GivenEnterDataInResourcePage(Table table)
        {
            var data = table.CreateInstance<ResourceData>();

            _resourcePage = new ResourcePage(data);
        }

        [When(@"press submit button")]
        public void WhenPressSubmitButton()
        {
            ResourcePage.Submit();
        }

        /// <summary>
        /// View resource detail
        /// </summary>
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

        #region Adding Resource require login
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
