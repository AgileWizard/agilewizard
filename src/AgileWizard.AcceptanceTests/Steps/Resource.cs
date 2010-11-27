﻿using System.Linq;
using TechTalk.SpecFlow;
using AgileWizard.AcceptanceTests.Helper;
using Xunit;

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
    }
}
