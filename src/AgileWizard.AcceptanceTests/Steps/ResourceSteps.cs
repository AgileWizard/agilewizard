using AgileWizard.AcceptanceTests.Helper;
using AgileWizard.AcceptanceTests.PageObject;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using AgileWizard.AcceptanceTests.Data;
using Xunit;

namespace AgileWizard.AcceptanceTests.Steps
{
  
    [Binding]
    public class ResourceSteps
    {
        private ResourceCreateEditPage _resourceCreateOrEditPage = null;

        [Given(@"open adding-resource page")]
        public void GivenOpenAddingResourcePage()
        {
            BrowserHelper.OpenPage("Resource/Create");
            _resourceCreateOrEditPage = BrowserHelper.Browser.Page<ResourceCreateEditPage>();
        }

        [Given(@"enter data in resource page")]
        public void GivenEnterDataInResourcePage(Table table)
        {
            var data = table.CreateInstance<ResourceData>();
            _resourceCreateOrEditPage.FillData(data);
        }

        [Given(@"press submit button")]
        public void GivenPressSubmitButton()
        {
            _resourceCreateOrEditPage.Submit();
        }

        [Then(@"current page should be resource details page")]
        public void ThenCurrentPageShouldBeResourceDetailsPage(Table table)
        {
            ResourceDetailsPage detailPage = BrowserHelper.Browser.Page<ResourceDetailsPage>();
            var data = table.CreateInstance<ResourceData>();
            detailPage.AssertPageData(data);
        }
    }
}
