using System;
using System.Web.Mvc;
using Xunit;

namespace AgileWizard.IntegrationTests.PageObject
{
    public class IntegrationTestBase
    {
        // route keys
        private const string _action = "action";
        private const string _controller = "controller";

        internal string ActionName { get; set; }
        internal string ControllerName { get; set; }

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

        protected void ActionResultCompare(RedirectToRouteResult actionResult, string routeKey, string expected)
        {
            Assert.Equal(expected, (string)actionResult.RouteValues[routeKey], StringComparer.OrdinalIgnoreCase);
        }
    }
}
