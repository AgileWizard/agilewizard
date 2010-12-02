using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        [Given(@"new account controller")]
        public void GivenNewAccountController()
        {
            var accountController = ObjectFactory.GetInstance<AccountController>();

            ScenarioContext.Current[Consts.SubjectUnderTest] = accountController;
        }

        [When(@"logon with username - '(\w+)' and password - '(\w+)'")]
        public void WhenLogonWithUsernameAndPassword(string userName, string password)
        {
            var accountController = ScenarioContext.Current[Consts.SubjectUnderTest] as AccountController;

            var result = accountController.LogOn(new LogOnModel
            {
                UserName = userName,
                Password = password,
            });

            ScenarioContext.Current[Consts.Result] = result;
        }

        [Then(@"return result should have controller - '(\w+)' and action - '(\w+)'")]
        public void ThenReturnResultShouldHaveControllerAndAction(string controller, string action)
        {
            var result = ScenarioContext.Current[Consts.Result] as RedirectToRouteResult;

            Assert.Equal(controller, (string)result.RouteValues["controller"], StringComparer.OrdinalIgnoreCase);
            Assert.Equal(action, (string)result.RouteValues["action"], StringComparer.OrdinalIgnoreCase);
        }
    }
}
