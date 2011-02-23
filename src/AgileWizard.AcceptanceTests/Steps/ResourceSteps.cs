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
        private ResourceListPage _listPage = null;

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
            ShowDetailPageAndValidateData(table);
        }

        [Then(@"open resource list page and validate culture and total count")]
        public void ThenOpenResourceListPageAndValidateCutltureAndTotalCount()
        {
            BrowserHelper.OpenPage("Resource/Index");
            _listPage = BrowserHelper.Browser.Page<ResourceListPage>();
            
            _listPage.AssertCulture();
            _listPage.AssertTotalResourceCount();
        }

        [Then(@"go resource edit page with title - (.+)")]
        public void ThenGoResourceEditPageWithTitle(string title)
        {
            _listPage.GoToResourceEdit(title);
        }

        [Then(@"update resource data")]
        public void ThenUpdateResourceData(Table table)
        {
            var data = table.CreateInstance<ResourceData>();
            _resourceCreateOrEditPage.FillData(data);
        }

        [Then(@"press submit button")]
        public void ThenPressSubmitButton()
        {
            _resourceCreateOrEditPage.Submit();
        }

        [Then(@"page should be redirected to details page")]
        public void ThenPageShouldBeRedirectedToDetailsPage(Table table)
        {
            ShowDetailPageAndValidateData(table);
        }

        [Then(@"go to resource list of tag '(.+)'")]
        public void ThenGoToResourceListOfTag(string tagName)
        {
            var detailPage = BrowserHelper.Browser.Page<ResourceDetailsPage>();
            detailPage.GoToTagList(tagName);
        }

        [Then(@"Then resource list of tag '(.+)' should have 1 item")]
        public void ThenThenResourceListOfTagShouldHave1Item(string tagName)
        {
            _listPage.AssertTotalResourceCount();
        }


        [Then(@"resource list of tag 'TestTag' should have 1 item")]
        public void ThenResourceListOfTagTestTagShouldHave1Item(string tagName)
        {
            _listPage.AssertTotalResourceCount();
        }
        
        private void ShowDetailPageAndValidateData(Table table)
        {
            ResourceDetailsPage detailPage = BrowserHelper.Browser.Page<ResourceDetailsPage>();
            var data = table.CreateInstance<ResourceData>();
            detailPage.AssertPageData(data);
        }

       
    }
}
