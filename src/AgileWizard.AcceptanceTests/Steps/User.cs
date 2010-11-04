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
    public class User
    {
        [Given(@"open login page")]
        public void GivenOpenLoginPage()
        {
            var browser = BrowserHelper.Browser;
            var url = BrowserHelper.ConstructUrl("Account/LogOn");

            browser.GoTo(url);
        }

        [Given(@"enter username - '(\w+)' and password - '(\w+)'")]
        public void GivenEnterUsernameAndPassword(string userName, string password)
        {
            var browser = BrowserHelper.Browser;

            browser.TextField("UserName").TypeText(userName);
            browser.TextField("Password").TypeText(password);
        }

        [When(@"press button - '([\w| ]+)'")]
        public void WhenPressButton(string butttonText)
        {
            var browser = BrowserHelper.Browser;

            browser.Button(x => x.Value == butttonText).Click();
        }


        [Then(@"should be redirected to main page")]
        public void ThenShouldBeRedirectedToMainPage()
        {
            var browser = BrowserHelper.Browser;

            Assert.Equal(BrowserHelper.WebsiteUrl, browser.Url);
        }

    }
}
