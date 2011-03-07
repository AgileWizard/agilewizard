using AgileWizard.Domain.Users;
using AgileWizard.IntegrationTests.PageObject;
using TechTalk.SpecFlow;
using AgileWizard.Website.Controllers;
using StructureMap;
using AgileWizard.Website.Models;
using System.Web.Mvc;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace AgileWizard.IntegrationTests.Steps
{
    [Binding]
    public class Account
    {
        private AccountController _accountController;
        private ActionResult _actionResult;
        private LogOnModel _logOnModel;
        private AccountCreateModel _accountCreateModel;

        #region Successful login

        [When(@"logon with correct username and password")]
        public void WhenLogonWithCorrectUsernameAndPassword()
        {
            LogonWithCorrectUserNameAndPassword();
        }

        [Then(@"navigate to home page")]
        public void ThenNavigateToHomePage()
        {
            var home = new Home();
            home.AssertNavigation(_actionResult as RedirectToRouteResult);
        }
        #endregion

        #region Failure login
        [When(@"logon username - (.+) and password - (.+)")]
        public void WhenLogonUsername(string username, string password)
        {
            LogonWithUserNameAndPassword(username, password);
        }

        [Then(@"no navigation")]
        public void ThenNoNavigation()
        {
            Assert.IsType<ViewResult>(_actionResult);
            Assert.Empty(((ViewResult)_actionResult).ViewName);
        }

        [Then(@"show error message")]
        public void ThenShowErrorMessage()
        {
            Assert.True(_accountController.ModelState.Values.Count > 0);
        }
        #endregion

        #region create a new account
        [When(@"try to create a account with following value")]
        public void WhenTryToCreateAccountWithNameAndPassword(Table table)
        {
            _accountCreateModel = GetAccountCreateModel(table);

            GetAccountController();

            CreateUser(_accountCreateModel);
        }

        [Then(@"create the account successfully")]
        public void ThenCreateAccountSuccessfully()
        {
            Assert.IsType<RedirectToRouteResult>(_actionResult);
            var accountCreatePage = new AccountCreateComplete();
            accountCreatePage.AssertNavigation(_actionResult as RedirectToRouteResult);

        }

        [Then(@"logout the current user")]
        public void LogoutCurrentAccount()
        {
            this._accountController.LogOff();
        }

        [Then(@"logon with the following account")]
        public void LogonWithAccountTable(Table table)
        {
            _logOnModel = table.CreateInstance<LogOnModel>();

            Logon();
        }

        private AccountCreateModel GetAccountCreateModel(Table table)
        {
            return table.CreateInstance<AccountCreateModel>();
        }

        private void CreateUser(AccountCreateModel accountCreateModel)
        {
            this._actionResult = this._accountController.Create(accountCreateModel);
        }
        #endregion

        #region private
        private void GetAccountController()
        {
            _accountController = ObjectFactory.GetInstance<AccountController>();
        }

        private void LogonWithCorrectUserNameAndPassword()
        {
            LogonWithUserNameAndPassword(User.DefaultUser().UserName, User.DefaultUser().Password);
        }

        private void LogonWithUserNameAndPassword(string username, string password)
        {
            _logOnModel = new LogOnModel
            {
                UserName = username,
                Password = password,
            };
            Logon();
        }

        private void Logon()
        {
            GetAccountController();

            _actionResult = _accountController.LogOn(_logOnModel);
        }
        #endregion
    }
}
