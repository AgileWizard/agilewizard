using System;
using System.Web.Mvc;
using Xunit;

namespace AgileWizard.IntegrationTests.PageObject
{
    public class IntegrationTestBase
    {
        private static string _action = "action";
        private const string _controller = "controller";
        private string ActionName { get; set; }
        private string ControllerName { get; set; }

        protected IntegrationTestBase(string controllerName, string actionName)
        {
            ControllerName = controllerName;
            ActionName = actionName;
        }

        public void AssertNavigation(RedirectToRouteResult actionResult)
        {
            AssertController(actionResult);

            AssertAction(actionResult);
        }

        public void AssertAction(RedirectToRouteResult actionResult)
        {
            ActionResultCompare(actionResult, _action, ActionName);
        }

        private void AssertController(RedirectToRouteResult actionResult)
        {
            ActionResultCompare(actionResult, _controller, ControllerName);
        }

        protected void ActionResultCompare(RedirectToRouteResult actionResult, string itemName, string expected)
        {
            Assert.Equal(expected, (string)actionResult.RouteValues[itemName], StringComparer.OrdinalIgnoreCase);
        }
    }
}
