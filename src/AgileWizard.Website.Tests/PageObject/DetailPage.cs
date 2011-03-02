using System.Web.Mvc;
using Xunit;

namespace AgileWizard.Website.Tests.PageObject
{
    public class DetailPage
    {
        private const string actionName = "Details";
        private const string ActionText = "action";
        private const string IDText = "id";

        public static void AssertRedirection(ActionResult actionResult, string id)
        {
            Assert.IsType<RedirectToRouteResult>(actionResult);
            Assert.Equal(actionName, ((RedirectToRouteResult)actionResult).RouteValues[ActionText].ToString());
            Assert.Equal(id, ((RedirectToRouteResult)actionResult).RouteValues[IDText].ToString());
        }
    }
}
