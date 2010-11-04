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
        public void GivenIOpenLoginPage()
        {
            var browser = BrowserHelper.Browser;
            var url = BrowserHelper.ConstructUrl("Account/LogOn");

            browser.GoTo(url);
        }

        [Given(@"enter username - '(\w+)' and password - '(\w+)'")]
        public void GivenIEnterUsername_AgilewizardAndPassword_Agilewizard(string userName, string password)
        {
            var browser = BrowserHelper.Browser;

            browser.TextField("UserName").TypeText(userName);
            browser.TextField("Password").TypeText(password);
        }

        [When(@"press button - '([\w| ]+)'")]
        public void WhenIPressButton(string butttonText)
        {
            var browser = BrowserHelper.Browser;

            browser.Button(x => x.Value == butttonText).Click();
        }


        [Then(@"should be redirected to main page")]
        public void ThenIShouldBeRedirectedToMainPage()
        {
            var browser = BrowserHelper.Browser;

            Assert.Equal(BrowserHelper.WebsiteUrl, browser.Url);
        }

    }
}
