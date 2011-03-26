using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using AgileWizard.AcceptanceTests.Helper;
using AgileWizard.AcceptanceTests.PageObject;
using AgileWizard.AcceptanceTests.Data;
using Xunit;

namespace AgileWizard.AcceptanceTests.Steps
{
    [Binding]
    public class AccountSteps
    {
        private AccountCreateEditPage _accountCreateOrEditPage;
        private AccountLogonPage _accountLogonPage;

        [Given(@"open adding-user page")]
        public void GivenOpenAddingResourcePage()
        {
            BrowserHelper.OpenPage("Account/Create");
            _accountCreateOrEditPage = BrowserHelper.Browser.Page<AccountCreateEditPage>();
        }

        [Given(@"enter data in account page")]
        public void GivenEnterDataInAccountPage(Table table)
        {
            var data = table.CreateInstance<AccountCreatData>();
            _accountCreateOrEditPage.FillData(data);
        }

        [Then(@"press submit button to create user")]
        public void GivenPressSubmitButton()
        {
            _accountCreateOrEditPage.Submit();
        }

        [Given(@"logout the current account")]
        public void LogoutCurrentAccount()
        {
            BrowserHelper.OpenPage("Account/Logoff");
        }

        [Then(@"open login page")]
        public void OpenLoginPage()
        {
            BrowserHelper.OpenPage("Account/Logon");
        }

        [Then(@"input account name and password")]
        public void InputUserNameAndPassword(Table table)
        {
            var data = table.CreateInstance<AccountData>();

            _accountLogonPage = BrowserHelper.Browser.Page<AccountLogonPage>();

            _accountLogonPage.UserName = data.UserName;
            _accountLogonPage.Password = data.Password;
        }

        [Then(@"logout the current account")]
        public void ThenLogoutCurrentAccount()
        {
            BrowserHelper.OpenPage("Account/Logoff");
        }

        [Then(@"login successfully")]
        public void LoginSuccessfully()
        {
            _accountLogonPage.Submit();

            var browser = BrowserHelper.Browser;
            Assert.Equal(BrowserHelper.WebsiteUrl, browser.Url);
        }


    }
}
