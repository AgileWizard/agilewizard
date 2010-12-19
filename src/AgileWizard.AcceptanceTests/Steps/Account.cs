using AgileWizard.AcceptanceTests.Helper;
using TechTalk.SpecFlow;
using Xunit;

namespace AgileWizard.AcceptanceTests.Steps
{
    [Binding]
    public class Account
    {
        [Given(@"open login page")]
        public void GivenOpenLoginPage()
        {
            BrowserHelper.OpenPage("Account/LogOn");
        }

        [Given(@"enter username - '(\w+)' and password - '(\w+)'")]
        public void GivenEnterUsernameAndPassword(string userName, string password)
        {
            BrowserHelper.InputText("UserName", userName);
            BrowserHelper.InputText("Password", password);
        }

        [When(@"press login button")]
        public void WhenPressLoginButton()
        {
            BrowserHelper.PressSubmitButton();
        }

        [Then(@"should be redirected to main page")]
        public void ThenShouldBeRedirectedToMainPage()
        {
            var browser = BrowserHelper.Browser;

            Assert.Equal(BrowserHelper.WebsiteUrl, browser.Url);
        }

    }
}
