using System;
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
        private RedirectToRouteResult _actionResult;
        private LogOnModel _logOnModel;

        [When(@"logon with correct username and password")]
        public void WhenLogonWithCorrectUsernameAndPassword()
        {
            GetAccountController();

            GetLogonModelWithCorrectUserNameAndPassword();

            _actionResult = _accountController.LogOn(_logOnModel) as RedirectToRouteResult;
        }

        private void GetAccountController()
        {
            _accountController = ObjectFactory.GetInstance<AccountController>();
        }

        private void GetLogonModelWithCorrectUserNameAndPassword()
        {
            _logOnModel = new LogOnModel
                              {
                                  UserName = User.DefaultUser().UserName,
                                  Password = User.DefaultUser().Password,
                              };
        }

        [Then(@"navigate to home page")]
        public void ThenNavigateToHomePage()
        {
            Home.AssertNavigateToHome(_actionResult);
        }
    }
}
