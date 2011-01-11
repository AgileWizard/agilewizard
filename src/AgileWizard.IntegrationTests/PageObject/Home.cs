using System;
using System.Web.Mvc;
using Xunit;

namespace AgileWizard.IntegrationTests.PageObject
{
    public class Home
    {
        private static string _action = "action";
        private const string _controller = "controller";
        private const string _controllerName = "home";
        private const string _actionName = "index";

        public static void AssertNavigateToHome(RedirectToRouteResult actionResult)
        {
            AssertController(actionResult);

            AssertAction(actionResult);
        }

        private static void AssertAction(RedirectToRouteResult actionResult)
        {
            ActionResultCompare(actionResult, _action, _actionName);
        }

        private static void AssertController(RedirectToRouteResult actionResult)
        {
            ActionResultCompare(actionResult, _controller, _controllerName);
        }

        private static void ActionResultCompare(RedirectToRouteResult actionResult, string itemName, string expected)
        {
            Assert.Equal(expected, (string)actionResult.RouteValues[itemName], StringComparer.OrdinalIgnoreCase);
        }
    }
}
