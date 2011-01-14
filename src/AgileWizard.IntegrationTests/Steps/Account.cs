using AgileWizard.Domain.Users;
using AgileWizard.IntegrationTests.PageObject;
using TechTalk.SpecFlow;
using AgileWizard.Website.Controllers;
using StructureMap;
using AgileWizard.Website.Models;
using System.Web.Mvc;
using Xunit;

namespace AgileWizard.IntegrationTests.Steps
{
    [Binding]
    public class Account
    {
        private AccountController _accountController;
        private ActionResult _actionResult;
        private LogOnModel _logOnModel;

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

        [When(@"logon username - (.+) and password - (.+)")]
        public void WhenLogonUsername(string username, string password)
        {
            LogonWithUserNameAndPassword(username, password);
        }

        [Then(@"no navigation")]
        public void ThenNoNavigation()
        {
            Assert.IsType<ViewResult>(_actionResult);
            Assert.Empty(((ViewResult)_actionResult).ViewName);        }

        [Then(@"show error message")]
        public void ThenShowErrorMessage()
        {
            Assert.True(_accountController.ModelState.Values.Count > 0);
        }

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
    }
}
