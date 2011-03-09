using TechTalk.SpecFlow;
using Xunit;

using AgileWizard.AcceptanceTests.Helper;
using AgileWizard.AcceptanceTests.PageObject;

namespace AgileWizard.AcceptanceTests.Steps
{
    [Binding]
    public class SharedSteps
    {
        private AccountLogonPage _accountPage = null;

        [Given(@"login already")]
        public void GivenLoginAlready()
        {
            BrowserHelper.OpenPage("Account/LogOn");
            _accountPage = BrowserHelper.Browser.Page<AccountLogonPage>();

            _accountPage.UserName = BrowserHelper.UserName;
            _accountPage.Password = BrowserHelper.Password;

            _accountPage.Submit();

            var browser = BrowserHelper.Browser;
            Assert.Equal(BrowserHelper.WebsiteUrl, browser.Url);
        }

        [Given("no login")]
        public void GivenNoLogin()
        {
            BrowserHelper.OpenPage("Account/Logoff");
        }

    }
}
