using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using AgileWizard.AcceptanceTests.Helper;
using Xunit;

namespace AgileWizard.AcceptanceTests.Steps
{
    [Binding]
    public class Resource
    {

        [Given(@"login already")]
        public void GivenLoginAlready()
        {
            //todo :-)
        }

        [Given(@"open adding-resource page")]
        public void GivenOpenAddingResourcePage()
        {
            SharedSteps.OpenPage("Resource/Create");
        }

        [Given(@"enter title - '([\w\s]+)' and content - '([\w\s]+)'")]
        public void GivenEnterTitleAndContent(string title, string content)
        {
            var browser = BrowserHelper.Browser;

            browser.TextFields.Single(s => s.Name == "Title").TypeText(title);
            browser.TextFields.Single(s => s.Name == "Content").TypeText(content);
        }

        [Then(@"should be redirected to list page")]
        public void ThenShouldBeRedirectedToListPage()
        {
            var browser = BrowserHelper.Browser;
            var suffix = "Resource";

            Assert.Equal(BrowserHelper.WebsiteUrl + suffix, browser.Url);
        }
    }
}
