using System.Web.Mvc;
using AgileWizard.Domain.Models;
using Xunit;

namespace AgileWizard.Website.Tests.PageObject
{
    public class DetailPage : OneResourcePageBase
    {
        private const string actionName = "Details";
        private const string ActionText = "action";
        private const string IDText = "id";

        public DetailPage(ActionResult actionResult) 
            : base(actionResult)
        {}

        public void AssertRedirection()
        {
            Assert.IsType<RedirectToRouteResult>(_actionResult);
            Assert.Equal(actionName, ((RedirectToRouteResult)_actionResult).RouteValues[ActionText].ToString());
            Assert.Equal(Resource.ID, ((RedirectToRouteResult)_actionResult).RouteValues[IDText].ToString());
        }

    }
}
