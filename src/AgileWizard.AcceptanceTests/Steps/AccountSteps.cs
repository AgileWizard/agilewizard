using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        [Given(@"open adding-account page")]
        public void GivenOpenAddingResourcePage()
        {
            BrowserHelper.OpenPage("Account/Create");
            _accountCreateOrEditPage = BrowserHelper.Browser.Page<AccountCreateEditPage>();
        }

        [Given(@"enter data in account page")]
        public void GivenEnterDataInAccountPage(Table table)
        {
            var data = table.CreateInstance<AccountData>();
            _accountCreateOrEditPage.FillData(data);
        }

        [Given(@"press submit button")]
        public void GivenPressSubmitButton()
        {
            _accountCreateOrEditPage.Submit();
        }

        [Given(@"logout the current account")]
        public void LogoutCurrentAccount()
        {
            BrowserHelper.OpenPage("Account/Logoff");
        }

        [Given(@"open login page")]
        public void OpenLoginPage()
        {
            BrowserHelper.OpenPage("Account/Logon");
        }

        [Given(@"input account name and password")]
        public void InputUserNameAndPassword(Table table)
        {
            var data = table.CreateInstance<AccountData>();

            _accountLogonPage = BrowserHelper.Browser.Page<AccountLogonPage>();

            _accountLogonPage.UserName = data.UserName;
            _accountLogonPage.Password = data.Password;

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
